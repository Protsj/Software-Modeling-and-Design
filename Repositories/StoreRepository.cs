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
        var existingCategory = GetCategoryById(category.id);
        if (existingCategory != null)
            existingCategory.name = category.name;
    }

	public void UpdateProduct(Product product)
    {
        var existingProduct = GetProductById(product.id);
        if (existingProduct != null)
        {
            existingProduct.category_id = product.category_id;
            existingProduct.name = product.name;
            existingProduct.count = product.count;
            if (product.info != null)
            {
                existingProduct.SetInfo(
                    product.info.compositions, 
                    product.info.calories, 
                    product.info.storage_conditions);
            }
        }
    }

    public void UpdateReceipt(Receipt receipt)
    {
        var existingReceipt = GetReceiptById(receipt.id);
        if (existingReceipt != null)
        {
            existingReceipt.status = receipt.status;
            existingReceipt.time = receipt.time;
            existingReceipt.customer_name = receipt.customer_name;
            existingReceipt.shop_name = receipt.shop_name;

            existingReceipt.ClearItems();
            foreach(var item in receipt.items)
                existingReceipt.AddItem(item.product_id, item.count);
        }
    }
}
