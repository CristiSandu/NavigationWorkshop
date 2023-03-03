using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NavSQLWS.Models;
using NavSQLWS.Services;
using NavSQLWS.Views;
using System.Collections.ObjectModel;

namespace NavSQLWS.ViewModels;

public partial class MainPageViewModel : BaseViewModel
{
    [ObservableProperty]
    List<MonkeyModel> monkeys;

    [ObservableProperty]
    MonkeyModel monkey;

    [ObservableProperty]
    MonkeyModel toSaveOnDB;


    private readonly DbConnection _dbConnection;
    public MainPageViewModel(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
        Title = "Monkey Page";
        Monkeys = new List<MonkeyModel>();
        ToSaveOnDB = new MonkeyModel(); // #added - instantiat mobelul 
        GetInitalDataCommand.Execute(null);
    }

    [RelayCommand]
    private async void GetInitalData()
    {
        Monkeys = await _dbConnection.GetItemsAsync();
    }

    [RelayCommand]
    private async void GoToBasicNavigation()
    {
        await Shell.Current.GoToAsync(nameof(NewPage2));
    }

    partial void OnMonkeyChanged(MonkeyModel value)
    {
        if (value == null) return;
        GoToMoreInfo();
    }

    [RelayCommand]
    private async void GoToMoreInfo()
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Monkey", Monkey }
        };

        Monkey = null;

        await Shell.Current.GoToAsync(nameof(InfoPage), navigationParameter);
    }

    [RelayCommand]
    private async void SaveOnDb()
    {
        await _dbConnection.SaveItemAsync(ToSaveOnDB);
        Monkeys = await _dbConnection.GetItemsAsync();
    }
}
