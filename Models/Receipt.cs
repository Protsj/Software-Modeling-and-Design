namespace StoreAutomatization.Models;

public class Receipt
{
	public int id { get; set; }
	public bool status { get; set; }
	public DateTime time { get; set; }
	public string customer_name { get; set; }
	public string shop_name { get; set; }

	public List<ReceiptItem> items { get; private set; } = new List<ReceiptItem>();

	public void AddItem(int productId, int count)
	{
		var newItem = new ReceiptItem
		{
			receipt_id = this.id,
			product_id = productId,
			count = count
		};
		items.Add(newItem);
	}

	public void ClearItems() { items.Clear();  }
}
