namespace CryptoList.Models;

public class Coin
{
    public string Id { get; set; }
    public string Symbol { get; set; }
    public string Name { get; set; }
    public decimal Current_Price { get; set; }
    public decimal Market_Cap { get; set; }
    public decimal Price_Change_Percentage_24h { get; set; }
    public string Image { get; set; }
}