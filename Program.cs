using StoreAutomatization.Data;
using StoreAutomatization.Services;
using StoreAutomatization.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        StoreRepository repository = new StoreRepository();
        MockData.Initialize(repository);
        StoreService service = new StoreService(repository);

        service.PrintFullProductInfo();

        Console.WriteLine("\nНатисніть Enter, щоб переглянути історію чеків...");
        Console.ReadLine();

        service.PrintAllReceiptsDetails();
    }
}