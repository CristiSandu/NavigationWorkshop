using NavSQLWS.ViewModels;

namespace NavSQLWS.Views;

public partial class InfoPage : ContentPage
{
    public InfoPage(InfoPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}