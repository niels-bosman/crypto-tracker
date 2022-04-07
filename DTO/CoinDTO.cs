namespace CryptoList.Models;

public class CoinDTO
{
    public string? Id { get; set; }
    public string? Symbol { get; set; }
    public string? Name { get; set; }
    public decimal Current_Price { get; set; }
    public decimal Market_Cap { get; set; }
    public decimal Price_Change_Percentage_24h { get; set; }
    public string? Image { get; set; }

    /// <summary>
    /// Check whether or not the price went up.
    /// </summary>
    /// <returns></returns>
    public bool PriceWentUp()
    {
        return Price_Change_Percentage_24h > 0;
    }
}