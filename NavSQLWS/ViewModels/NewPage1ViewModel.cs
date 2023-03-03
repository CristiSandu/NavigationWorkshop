using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace NavSQLWS.ViewModels;
public partial class NewPage1ViewModel : BaseViewModel
{
    [ObservableProperty]
    bool isTabBarVisible;

    public NewPage1ViewModel()
    {

    }

    [RelayCommand]
    private void ChangeVisibility()
    {
        IsTabBarVisible = !IsTabBarVisible;
    }

    [RelayCommand]
    private void MoveToANewTab()
    {
        Shell.Current.CurrentItem = Shell.Current.Items[0].Items[2];
    }
}
