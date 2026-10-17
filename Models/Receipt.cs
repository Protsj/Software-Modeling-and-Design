namespace StoreAutomatization.Models;

public class Receipt
{
	public int id { get; set; }
	public bool status { get; set; }
	public DateTime time { get; set; }
	public string customer_name { get; set; }
	public string shop_name { get; set; }
}
