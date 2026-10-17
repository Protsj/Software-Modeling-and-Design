namespace StoreAutomatization.Repositories;
using StoreAutomatization.Models;

public class StoreRepository
{
	private List<Category> _categories = new List<Category>();
    private List<Product> _products = new List<Product>();
	private List<ProductInfo> _product_infos = new List<ProductInfo>();
	private List<Receipt> _receipts = new List<Receipt>();
	private List<ReceiptItem> _receipt_items = new List<ReceiptItem>();

	public List<Category> GetAllCategories() => _categories;
	public List<Product> GetAllProducts() => _products;
	public List<ProductInfo> GetAllProductInfos() => _product_infos;
	public List<Receipt> GetAllReceipts() => _receipts;
	public List<ReceiptItem> GetAllReceiptItems() => _receipt_items;

	public Category GetCategoryById(int id) { return _categories.FirstOrDefault(c => c.id == id); }
	public Product GetProductById(int id) { return _products.FirstOrDefault(p => p.id == id); }
	public ProductInfo GetProductInfoById(int id) { return _product_infos.FirstOrDefault(pi => pi.id == id); }
	public Receipt GetReceiptById(int id) { return _receipts.FirstOrDefault(r => r.id == id); }
	public ReceiptItem GetReceiptItemById(int receiptId, int productId) { return _receipt_items.FirstOrDefault(ri => ri.receipt_id == receiptId && ri.product_id == productId); }

	public void AddCategory(Category category) { _categories.Add(category); }
    public void AddProduct(Product product) { _products.Add(product); }
	public void AddProductInfo(ProductInfo productInfo) { _product_infos.Add(productInfo); }
	public void AddReceipt(Receipt receipt) { _receipts.Add(receipt); }
	public void AddReceiptItem(ReceiptItem receiptItem) { _receipt_items.Add(receiptItem); }

	public void DeleteCategory(int id) { _categories.RemoveAll(c => c.id == id); }
    public void DeleteProduct(int id) { _products.RemoveAll(p => p.id == id); }
	public void DeleteProductInfo(int id) { _product_infos.RemoveAll(pi => pi.id == id); }
    public void DeleteReceipt(int id) { _receipts.RemoveAll(r => r.id == id); }
	public void DeleteReceiptItem(int receiptId, int productId) { _receipt_items.RemoveAll(ri => ri.receipt_id == receiptId && ri.product_id == productId); }

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
        }
    }

	public void UpdateProductInfo(ProductInfo productInfo)
    {
        var existingProductInfo = GetProductInfoById(productInfo.id);
        if (existingProductInfo != null)
        {
            existingProductInfo.product_id = productInfo.product_id;
            existingProductInfo.compositions = productInfo.compositions;
            existingProductInfo.calories = productInfo.calories;
            existingProductInfo.storage_conditions = productInfo.storage_conditions;
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
        }
    }

    public void UpdateReceiptItem(ReceiptItem receiptItem)
    {
        var existingReceiptItem = GetReceiptItemById(receiptItem.receipt_id, receiptItem.product_id);
        if (existingReceiptItem != null)
        {
            existingReceiptItem.count = receiptItem.count;
        }
    }
}
