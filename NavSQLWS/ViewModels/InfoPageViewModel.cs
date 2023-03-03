using CommunityToolkit.Mvvm.ComponentModel;
using NavSQLWS.Models;

namespace NavSQLWS.ViewModels;

public partial class InfoPageViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty]
    MonkeyModel monkey = new();

    public InfoPageViewModel()
    {

    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Monkey = query["Monkey"] as MonkeyModel; 
    }
}
