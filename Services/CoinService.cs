using CryptoList.DTO;

namespace CryptoList.Services;

public class CoinService
{
    private const string ApiBase = "https://api.coingecko.com/api/";
    private const string ApiVersion = "3";
    private const string ApiUri = $"{ApiBase}v{ApiVersion}";
    
    private static readonly HttpClient Http = new();

    public static async Task<CoinDetailDTO?> FetchCoinDetails(string? coin)
    {
        var details = await Http.GetFromJsonAsync<CoinDetailDTO>($"{ApiUri}/coins/{coin}");

        return details;
    }
}