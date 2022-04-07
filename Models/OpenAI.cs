namespace CryptoList.Models;

public class OpenAI
{
    public string id { get; set; }
    public int created { get; set; }
    public string model { get; set; }
    public List<Choice> choices { get; set; }
}