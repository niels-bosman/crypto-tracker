using CryptoList.Models;

namespace CryptoList.Services;

public class FetchCoinsService : BackgroundService
{
    private const string ApiBase = "https://api.coingecko.com/api/";
    private const string ApiVersion = "3";
    private const string ApiUri = $"{ApiBase}v{ApiVersion}";
    
    private static readonly HttpClient Http = new();
    public static event Func<List<Coin>, Task> UpdateEvent;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(3), stoppingToken);
            var coins = await FetchCoins();
            await UpdateEvent.Invoke(coins);
        }
    }

    private static async Task<List<Coin>> FetchCoins()
    {
        const string endpoint = $"{ApiUri}/coins/markets?vs_currency=eur&order=market_cap_desc&per_page=100&page=1&price_change_percentage=1h%2C24h%2C7d";
        var response = await Http.GetFromJsonAsync<List<Coin>>(endpoint);
        return response ?? new List<Coin>();
    }
}