namespace StoreAutomatization.Models;

public class Product
{
	public int id { get; set; }
    public int category_id { get; set; }
    public string name { get; set; }
	public int count { get; set; }

    public ProductInfo info { get; private set; }

    public void SetInfo(string compositions, int calories, string storage_conditions)
    {
        this.info = new ProductInfo
        {
            compositions = compositions,
            calories = calories,
            storage_conditions = storage_conditions
        };
    }
}
