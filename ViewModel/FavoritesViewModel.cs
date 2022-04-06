using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CryptoList.ViewModel;

public class FavoritesViewModel: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public List<string> FavoriteCoins { get; } = new();

    public void ToggleFavorite(string id)
    {
        if (FavoriteCoins.Contains(id))
        {
            FavoriteCoins.Remove(id);
        }
        else
        {
            FavoriteCoins.Add(id);
        }
        
        OnPropertyChanged();
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    } 
}