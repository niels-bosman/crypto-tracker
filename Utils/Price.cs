using System.Globalization;

namespace CryptoList.Utils;

public class Price
{
    private decimal _price { get; }
    
    public Price(decimal price)
    {
        _price = price;
    }

    public string GetPretty()
    {
        return _price.ToString("C", new CultureInfo("nl-NL"));
    }
}