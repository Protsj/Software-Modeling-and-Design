namespace StoreAutomatization.Repositories;
using StoreAutomatization.Models;

public class StoreRepository
{
	private List<Category> _categories = new List<Category>();
    private List<Product> _products = new List<Product>();
	private List<Receipt> _receipts = new List<Receipt>();

	public List<Category> GetAllCategories() => _categories;
	public List<Product> GetAllProducts() => _products;
	public List<Receipt> GetAllReceipts() => _receipts;

	public Category GetCategoryById(int id) { return _categories.FirstOrDefault(c => c.id == id); }
	public Product GetProductById(int id) { return _products.FirstOrDefault(p => p.id == id); }
	public Receipt GetReceiptById(int id) { return _receipts.FirstOrDefault(r => r.id == id); }

	public void AddCategory(Category category) { _categories.Add(category); }
    public void AddProduct(Product product) { _products.Add(product); }
	public void AddReceipt(Receipt receipt) { _receipts.Add(receipt); }

	public void DeleteCategory(int id) { _categories.RemoveAll(c => c.id == id); }
    public void DeleteProduct(int id) { _products.RemoveAll(p => p.id == id); }
    public void DeleteReceipt(int id) { _receipts.RemoveAll(r => r.id == id); }

	public void UpdateCategory(Category category)
    {
        int index = _categories.FindIndex(c => c.id == category.id);
        if (index != -1)
            _categories[index] = category;
    }

	public void UpdateProduct(Product product)
    {
        int index = _products.FindIndex(p => p.id == product.id);
        if (index != -1)
            _products[index] = product;
    }

    public void UpdateReceipt(Receipt receipt)
    {
        int index = _receipts.FindIndex(r => r.id == receipt.id);
        if (index != -1)
            _receipts[index] = receipt;
    }
}
