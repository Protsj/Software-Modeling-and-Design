using StoreAutomatization.Data;
using StoreAutomatization.Services;
using StoreAutomatization.Repositories;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Logger.Initialize();

        try
        {
            Logger.LogInfo("Систему автоматизації магазину запущено.");

            StoreRepository repository = new StoreRepository();
            MockData.Initialize(repository);
            StoreService service = new StoreService(repository);

            Console.WriteLine("\n=== ДЕТАЛЬНИЙ КАТАЛОГ ТОВАРІВ (Доступно всім) ===");
            service.PrintFullProductInfo();

            Console.WriteLine("\n=== ТЕСТ БЕЗПЕКИ: ДІЯ БЕЗ АВТОРИЗАЦІЇ ===");
            service.AddNewProduct("Спроба злому", 1, 1, "-", 0, "-");

            Console.WriteLine("\n=== РОБОТА АДМІНІСТРАТОРА ===");
            SecurityManager.Authenticate("admin", "admin123");
            service.AddNewProduct("Енергетик Monster", 30, 50, "Вода, таурин, кофеїн", 45, "Від 0°C до +25°C");
            SecurityManager.Logout();

            Console.WriteLine("\n=== РОБОТА КАСИРА ===");
            SecurityManager.Authenticate("cashier", "cashier123");

            int activeReceiptId = service.OpenNewReceipt("Іван", "АТБ");

            if (activeReceiptId != -1)
            {
                service.ScanProductToReceipt(activeReceiptId, 1, 3);
                service.ScanProductToReceipt(activeReceiptId, productId: 28, countToBuy: 2);
                service.CloseReceipt(activeReceiptId);
            }

            int emptyReceiptId = service.OpenNewReceipt("Олена", "Сільпо");
            Logger.LogInfo("Спроба закрити порожній чек...");
            service.CloseReceipt(emptyReceiptId);

            service.CancelReceipt(emptyReceiptId);

            Logger.LogInfo("Спроба відсканувати товар у скасований чек...");
            try { service.ScanProductToReceipt(emptyReceiptId, 1, 1); }
            catch (Exception ex) { Logger.LogError(ex.Message); }

            Console.WriteLine("\n=== ТЕСТ БЕЗПЕКИ: КАСИР НАМАГАЄТЬСЯ ДОДАТИ ТОВАР ===");
            service.AddNewProduct("Товар від касира", 1, 10, "-", 0, "-");
            SecurityManager.Logout();

            Console.WriteLine("\n=== ПЕРЕГЛЯД РЕЗУЛЬТАТІВ (АДМІНІСТРАТОР) ===");
            SecurityManager.Authenticate("admin", "admin123");
            service.PrintAllReceiptsDetails();
            SecurityManager.Logout();
        }
        catch(Exception ex)
        {
            Serilog.Log.Fatal(ex, "Виникла критична помилка під час роботи системи.");
        }
        finally
        {
            Logger.Close();
        }
    }
}