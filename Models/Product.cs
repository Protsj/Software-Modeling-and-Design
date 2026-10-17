namespace StoreAutomatization.Models;

public class Product
{
	public int id { get; set; }
    public int category_id { get; set; }
    public string name { get; set; }
	public int count { get; set; }
}
