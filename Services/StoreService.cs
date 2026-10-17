namespace StoreAutomatization.Services;
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
            var info = _repo.GetProductInfoById(product.id);
            string categoryName = category != null ? category.name : "Невідома категорія";
            Console.WriteLine($"[ID: {product.id}] {product.name} ({categoryName}) - Залишок: {product.count} шт.");
            if (info != null)
                Console.WriteLine($"    -> Склад: {info.compositions} | Калорійність: {info.calories} ккал | Зберігання: {info.storage_conditions}");
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
            
            var itemsInReceipt = _repo.GetAllReceiptItems().Where(ri => ri.receipt_id == receipt.id).ToList();
            if (itemsInReceipt.Count == 0)
            {
                Console.WriteLine("  - Чек порожній.");
                continue;
            }

            foreach (var item in itemsInReceipt)
            {
                var product = _repo.GetProductById(item.product_id);
                string productName = product != null ? product.name : "Невідомий товар";

                Console.WriteLine($"  - {productName}: {item.count} шт.");
            }
            Console.WriteLine(new string('-', 30));
        }
    }
}
