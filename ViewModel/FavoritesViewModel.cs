using System.ComponentModel;
using System.Runtime.CompilerServices;
using CryptoList.Annotations;

namespace CryptoList.ViewModel;

public class FavoritesViewModel: IFavoritesViewModel, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public List<string> FavoriteCoins { get; set; } = new();

    /// <summary>
    /// Add a favorite coin.
    /// </summary>
    /// <param name="id"></param>
    public void AddFavorite(string id)
    {
        if (FavoriteCoins.Contains(id)) return;

        FavoriteCoins.Add(id);
        OnPropertyChanged();
    }

    /// <summary>
    /// Remove a favorite coin.
    /// </summary>
    public void RemoveFavorite(string id)
    {
        if (!FavoriteCoins.Contains(id)) return;

        FavoriteCoins.Remove(id);
        OnPropertyChanged();
    }

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    } 
}