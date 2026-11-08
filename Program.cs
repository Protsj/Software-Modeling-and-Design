using StoreAutomatization.Data;
using StoreAutomatization.Services;
using StoreAutomatization.Repositories;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        StoreRepository repository = new StoreRepository();
        MockData.Initialize(repository);
        StoreService service = new StoreService(repository);

        service.PrintFullProductInfo();

        Console.WriteLine("\n=== РОБОТА АДМІНІСТРАТОРА ===");
        service.AddNewProduct("Енергетик Monster", 30, 50, "Вода, таурин, кофеїн", 45, "Від 0°C до +25°C");

        Console.WriteLine("\n=== РОБОТА КАСИРА ===");
        int activeReceiptId = service.OpenNewReceipt("Іван", "АТБ");

        service.ScanProductToReceipt(activeReceiptId, 1, 3); // Купує 3 яблука
        service.ScanProductToReceipt(activeReceiptId, productId: 30, countToBuy: 2); // Купує наш новий енергетик (ID буде 28, бо в MockData їх 27) **Перевірка на правильність ID**

        service.CloseReceipt(activeReceiptId);

        Console.WriteLine("\n=== ПЕРЕГЛЯД РЕЗУЛЬТАТІВ (АДМІНІСТРАТОР) ===");
        service.PrintAllReceiptsDetails();

        Console.ReadLine();
    }
}