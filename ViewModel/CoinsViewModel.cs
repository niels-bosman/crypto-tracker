using System.ComponentModel;
using System.Timers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using CryptoList.Annotations;
using CryptoList.Models;
using Timer = System.Timers.Timer;

namespace CryptoList.ViewModel;

public class CoinsViewModel : ICoinsViewModel, INotifyPropertyChanged
{
    private const string ApiBase = "https://api.coingecko.com/api/";
    private const string ApiVersion = "3";
    private const string ApiUri = $"{ApiBase}v{ApiVersion}";
    
    public event PropertyChangedEventHandler? PropertyChanged;
    private static readonly HttpClient Http = new();
    private const int TimerInterval = 3000;
    private Timer? _timer;
    private bool _running;
    public List<Coin> Coins { get; set; } = new();

    /// <summary>
    /// Executes a timer to fetch all coins every 5 seconds.
    /// </summary>
    public void ExecuteFetchTimer()
    {
        if (_running) return;
        
        _timer = new Timer();
        _timer.Interval = TimerInterval;
        _timer.Elapsed += FetchCoins!;
        _timer.AutoReset = true;
        _timer.Enabled = true;
        _running = true;
    }

    /// <summary>
    /// Fetches all of the coins and notifies the UI.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    public async void FetchCoins(object? source, ElapsedEventArgs? e)
    {
        const string endpoint = $"{ApiUri}/coins/markets?vs_currency=eur&order=market_cap_desc&per_page=100&page=1&price_change_percentage=1h%2C24h%2C7d";
        var response = await Http.GetFromJsonAsync<List<Coin>>(endpoint);
        Coins = response ?? new List<Coin>();
        OnPropertyChanged();
    }

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}