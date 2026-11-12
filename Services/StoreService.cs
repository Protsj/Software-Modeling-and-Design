namespace StoreAutomatization.Services;

using StoreAutomatization.Models;
using StoreAutomatization.Repositories;

public class StoreService
{
    private readonly StoreRepository _repo;

    public StoreService(StoreRepository repo) { _repo = repo; }

    public void PrintFullProductInfo()
    {
        var products = _repo.GetAllProducts();
        foreach (var product in products)
        {
            var category = _repo.GetCategoryById(product.category_id);
            string categoryName = category != null ? category.name : "Невідома категорія";
            Logger.LogInfo("[ID: {ProductId}] {ProductName} ({CategoryName}) - Залишок: {AvailableCount} шт.", product.id, product.name, categoryName, product.count);
            if (product.info != null)
                Logger.LogInfo("    -> Склад: {Compositions} | Калорійність: {Calories} ккал | Зберігання: {StorageConditions}", product.info.compositions, product.info.calories, product.info.storage_conditions);
        }
    }

    public void PrintAllReceiptsDetails()
    {
        var receipts = _repo.GetAllReceipts();
        foreach (var receipt in receipts)
        {
            string statusStr = receipt.state == ReceiptState.Open ? "Відкритий" : receipt.state == ReceiptState.Paid ? "Оплачений" : "Скасований";
            Logger.LogInfo("Чек #{ReceiptId} | Магазин: {ShopName} | Покупець: {CustomerName}", receipt.id, receipt.shop_name, receipt.customer_name);
            Logger.LogInfo("Час: {ReceiptTime} | Статус: {Status}", receipt.time, statusStr);
            Logger.LogInfo("Позиції в чеку:");
            
            if(receipt.items.Count == 0)
            {
                Logger.LogInfo("Чек #{ReceiptId} порожній.", receipt.id);
                continue;
            }

            foreach (var item in receipt.items)
            {
                var product = _repo.GetProductById(item.product_id);
                string productName = product != null ? product.name : "Невідомий товар";

                Logger.LogInfo("  - {ProductName}: {Count} шт.", productName, item.count);
            }
            Logger.LogInfo(new string('-', 30));
        }
    }

    public void ScanProductToReceipt(int receiptId, int productId, int countToBuy)
    {
        if (SecurityManager.CurrentRole != UserRole.Cashier)
        {
            Logger.LogError("Відмовлено в доступі: Сканувати товари може лише Касир.");
            return;
        }

        var receipt = _repo.GetReceiptById(receiptId);
        var product = _repo.GetProductById(productId);

        if(receipt == null)
        {
            Logger.LogError("Чек #{ReceiptId} не знайдено.", receiptId);
            return;
        }
        if (product == null)
        {
            Logger.LogError("Товар #{ProductId} не знайдено.", productId);
            return;
        }
        if(product.count < countToBuy)
        {
            Logger.LogError("Відмова: Недостатньо товару '{ProductName}'. В наявності: {AvailableCount}, Замовлено: {CountToBuy}.",
                product.name, product.count, countToBuy);
            return;
        }

        receipt.AddItem(productId, countToBuy);
        product.count -= countToBuy;

        _repo.UpdateProduct(product);
        _repo.UpdateReceipt(receipt);
        Logger.LogInfo("Товар '{ProductName}' ({CountToBuy} шт.) додано до чека #{ReceiptId}.",
            product.name, countToBuy, receiptId);
    }

    public int OpenNewReceipt(string customerName, string shopName)
    {
        if (SecurityManager.CurrentRole != UserRole.Cashier)
        {
            Logger.LogError("Відмовлено в доступі: створювати чеки може лише Касир.");
            return -1;
        }

        int newId = _repo.GetAllReceipts().Count > 0 ? _repo.GetAllReceipts().Max(r => r.id) + 1 : 1;
        
        var receipt = new Receipt
        {
            id = newId,
            time = DateTime.Now,
            customer_name = customerName,
            shop_name = shopName
        };

        _repo.AddReceipt(receipt);
        Logger.LogInfo("Відкрито новий чек #{ReceiptId} для покупця {CustomerName}.", newId, customerName);

        return newId;
    }

    public void CloseReceipt(int receiptId)
    {
        if (SecurityManager.CurrentRole != UserRole.Cashier)
        {
            Logger.LogError("Відмовлено в доступі: Закривати чеки може лише Касир.");
            return;
        }

        var receipt = _repo.GetReceiptById(receiptId);
        if(receipt == null)
        {
            Logger.LogError("Чек #{ReceiptId} не знайдено.", receiptId);
            return;
        }
        try
        {
            receipt.Pay();
            _repo.UpdateReceipt(receipt);
            Logger.LogInfo("Чек #{ReceiptId} успішно закрито та оплачено.", receiptId);
        }
        catch (Exception ex)
        {
            Logger.LogError("Помилка оплати чека #{ReceiptId}: {Message}", receiptId, ex.Message);
            return;
        }
        
    }

    public void CancelReceipt(int receiptId)
    {
        if (SecurityManager.CurrentRole != UserRole.Cashier)
        {
            Logger.LogError("Відмовлено в доступі: скасовувати чеки може лише Касир.");
            return;
        }

        var receipt = _repo.GetReceiptById(receiptId);
        if (receipt == null) return;

        try
        {
            receipt.Cancel();
            _repo.UpdateReceipt(receipt);
            Logger.LogInfo("Чек #{ReceiptId} було СКАСОВАНО.", receiptId);
        }
        catch (Exception ex)
        {
            Logger.LogError("Помилка скасування чека #{ReceiptId}: {Message}", receiptId, ex.Message);
        }
    }

    public void AddNewProduct(string name, int categoryId, int count, string compositions, int calories, string storageConditions)
    {
        if(SecurityManager.CurrentRole != UserRole.Admin)
        {
            Logger.LogError("Відмовлено в доступі: Додавати нові товари може лише Адміністратор.");
            return;
        }

        int newId = _repo.GetAllProducts().Count > 0 ? _repo.GetAllProducts().Max(p => p.id) + 1 : 1;
        
        var product = new Product
        {
            id = newId,
            name = name,
            category_id = categoryId,
            count = count
        };

        product.SetInfo(compositions, calories, storageConditions);
        _repo.AddProduct(product);
        Logger.LogInfo("Адміністратор додав новий товар: '{ProductName}' (ID: {ProductId}) у кількості {Count} шт.", name, newId, count);
    }
}
