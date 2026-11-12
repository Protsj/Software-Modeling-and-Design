namespace StoreAutomatization.Models;

public class Receipt
{
	public int id { get; set; }
	public ReceiptState state { get; private set; } = ReceiptState.Open;
    public DateTime time { get; set; }
	public string customer_name { get; set; }
	public string shop_name { get; set; }

	public List<ReceiptItem> items { get; private set; } = new List<ReceiptItem>();

	public void AddItem(int productId, int count)
	{
		if (state != ReceiptState.Open)
			throw new InvalidOperationException("Неможливо додати товар: чек вже закритий або скасований.");

		var newItem = new ReceiptItem
		{
			receipt_id = this.id,
			product_id = productId,
			count = count
		};
		items.Add(newItem);
	}
	
	public void Pay()
	{
		if (state != ReceiptState.Open)
            throw new InvalidOperationException("Оплатити можна лише відкритий чек.");
		if (items.Count == 0)
            throw new InvalidOperationException("Неможливо оплатити порожній чек (потрібен хоча б 1 товар).");

        state = ReceiptState.Paid;
	}

	public void Cancel()
    {
        if (state != ReceiptState.Open)
            throw new InvalidOperationException("Скасувати можна лише відкритий чек.");
        state = ReceiptState.Canceled;
    }

    public void ClearItems() { items.Clear(); }
}
