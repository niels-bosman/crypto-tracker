using System.ComponentModel;

namespace CryptoList.ViewModel;

public interface IFavoritesViewModel
{
   event PropertyChangedEventHandler? PropertyChanged;

   List<string> FavoriteCoins { get; set; }

   void AddFavorite(string id);
   
   void RemoveFavorite(string id);
}