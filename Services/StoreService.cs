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
        Console.WriteLine("\nДЕТАЛЬНИЙ КАТАЛОГ ТОВАРІВ");
        foreach (var product in products)
        {
            var category = _repo.GetCategoryById(product.category_id);
            string categoryName = category != null ? category.name : "Невідома категорія";
            Console.WriteLine($"[ID: {product.id}] {product.name} ({categoryName}) - Залишок: {product.count} шт.");
            if (product.info != null)
                Console.WriteLine($"    -> Склад: {product.info.compositions} | Калорійність: {product.info.calories} ккал | Зберігання: {product.info.storage_conditions}");
        }
    }

    public void PrintAllReceiptsDetails()
    {
        var receipts = _repo.GetAllReceipts();
        Console.WriteLine("\nІСТОРІЯ ЧЕКІВ");
        foreach (var receipt in receipts)
        {
            string statusStr = receipt.status ? "ОПЛАЧЕНО" : "СКАСОВАНО";
            Console.WriteLine($"\nЧек #{receipt.id} | Магазин: {receipt.shop_name} | Покупець: {receipt.customer_name}");
            Console.WriteLine($"Час: {receipt.time} | Статус: {statusStr}");
            Console.WriteLine("Позиції в чеку:");
            
            if(receipt.items.Count == 0)
            {
                Console.WriteLine("  (Чек порожній)");
                continue;
            }

            foreach (var item in receipt.items)
            {
                var product = _repo.GetProductById(item.product_id);
                string productName = product != null ? product.name : "Невідомий товар";

                Console.WriteLine($"  - {productName}: {item.count} шт.");
            }
            Console.WriteLine(new string('-', 30));
        }
    }

    public void ScanProductToReceipt(int receiptId, int productId, int countToBuy)
    {
        var receipt = _repo.GetReceiptById(receiptId);
        var product = _repo.GetProductById(productId);

        if(receipt == null)
        {
            Console.WriteLine($"[Помилка] Чек #{receiptId} не знайдено.");
            return;
        }
        if (product == null)
        {
            Console.WriteLine($"[Помилка] Товар #{productId} не знайдено.");
            return;
        }
        if(product.count < countToBuy)
        {
            Console.WriteLine($"[Відмова] Недостатньо товару '{product.name}' на складі. В наявності: {product.count}, Замовлено: {countToBuy}.");
            return;
        }

        receipt.AddItem(productId, countToBuy);
        product.count -= countToBuy;

        _repo.UpdateProduct(product);
        _repo.UpdateReceipt(receipt);
        Console.WriteLine($"[Успіх] {countToBuy} шт. товару '{product.name}' додано до чека #{receiptId}.");
    }

    public int OpenNewReceipt(string customerName, string shopName)
    {
        int newId = _repo.GetAllReceipts().Count > 0 ? _repo.GetAllReceipts().Max(r => r.id) + 1 : 1;
        
        var receipt = new Receipt
        {
            id = newId,
            status = false,
            time = DateTime.Now,
            customer_name = customerName,
            shop_name = shopName
        };

        _repo.AddReceipt(receipt);
        Console.WriteLine($"[Система] Відкрито новий чек #{newId} для покупця {customerName}.");

        return newId;
    }

    public void CloseReceipt(int receiptId)
    {
        var receipt = _repo.GetReceiptById(receiptId);
        if(receipt == null)
        {
            Console.WriteLine($"[Помилка] Чек #{receiptId} не знайдено.");
            return;
        }

        receipt.status = true;
        _repo.UpdateReceipt(receipt);
        Console.WriteLine($"[Система] Чек #{receiptId} успішно закрито та оплачено.");
    }

    public void AddNewProduct(string name, int categoryId, int count, string compositions, int calories, string storageConditions)
    {
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
        Console.WriteLine($"[Система] Адміністратор додав новий товар: '{name}' (ID: {newId}) у кількості {count} шт.");
    }
}
