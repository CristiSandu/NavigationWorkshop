﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NavSQLWS.Models;
using NavSQLWS.Services;
using NavSQLWS.Views;
using System.Collections.ObjectModel;

namespace NavSQLWS.ViewModels;

public partial class MainPageViewModel : BaseViewModel
{
    [ObservableProperty]
    ObservableCollection<MonkeyModel> monkeys;

    [ObservableProperty]
    MonkeyModel monkey;

    [ObservableProperty]
    MonkeyModel toSaveOnDB;


    private readonly DbConnection _dbConnection;
    public MainPageViewModel(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
        Title = "Monkey Page";
        Monkeys = new ObservableCollection<MonkeyModel>();
        ToSaveOnDB = new MonkeyModel();
        GetInitalDataCommand.Execute(null);

        //Monkeys = new List<MonkeyModel>
        //{
        //    new MonkeyModel
        //    {
        //        Name = "Baboon",
        //        Location = "Africa & Asia",
        //        Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
        //        Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg",
        //        Population = 10000,
        //        Latitude = -8.783195,
        //        Longitude = 34.508523
        //    },
        //    new MonkeyModel
        //    {
        //        Name = "Capuchin Monkey",
        //        Location = "Central & South America",
        //        Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
        //        Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg",
        //        Population = 23000,
        //        Latitude = 12.769013,
        //        Longitude = -85.602364
        //    },
        //     new MonkeyModel
        //    {
        //        Name = "Blue Monkey",
        //        Location = "Central and East Africa",
        //        Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia",
        //        Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/bluemonkey.jpg",
        //        Population = 12000,
        //        Latitude = 1.957709,
        //        Longitude = 37.297204
        //    },
        //};
    }

    [RelayCommand]
    private async void GetInitalData()
    {
        Monkeys = new ObservableCollection<MonkeyModel>(await _dbConnection.GetItemsAsync());
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
        Monkeys = new ObservableCollection<MonkeyModel>(await _dbConnection.GetItemsAsync());
    }
}
