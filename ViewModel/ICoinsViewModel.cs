using System.ComponentModel;
using System.Timers;
using CryptoList.Models;

namespace CryptoList.ViewModel;

public interface ICoinsViewModel
{
   List<Coin> Coins { get; set; }
   void ExecuteFetchTimer();
   void FetchCoins(object? source, ElapsedEventArgs? e);
   event PropertyChangedEventHandler PropertyChanged;
}