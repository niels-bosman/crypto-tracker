using CryptoList.Models;

namespace CryptoList.Services;

public class FetchCoinsBackgroundService : BackgroundService
{
    private const string ApiBase = "https://api.coingecko.com/api/";
    private const string ApiVersion = "3";
    private const string ApiUri = $"{ApiBase}v{ApiVersion}";

    private const string Currency = "eur";
    private const string Order = "market_cap_desc";
    private const string PerPage = "250";
    private const string PriceChangePercentage = "1h%2C24h%2C7d";

    private static readonly HttpClient Http = new();
    public static event Func<List<CoinDTO>, Task>? UpdateEvent;

    /// <summary>
    /// Excecute the task every n seconds.
    /// </summary>
    /// <param name="token"></param>
    protected override async Task ExecuteAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(2), token);
            var coins = await FetchCoins();
            if (UpdateEvent != null) await UpdateEvent.Invoke(coins);
        }
    }

    /// <summary>
    /// Fetch coins from CoinGecko API.
    /// </summary>
    /// <returns></returns>
    private static async Task<List<CoinDTO>> FetchCoins()
    {
        const string endpoint = $"{ApiUri}/coins/markets?vs_currency={Currency}&order={Order}&per_page={PerPage}&price_change_percentage={PriceChangePercentage}";
        var response = await Http.GetFromJsonAsync<List<CoinDTO>>(endpoint);
        return response ?? new List<CoinDTO>();
    }
}