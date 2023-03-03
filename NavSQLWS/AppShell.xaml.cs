using NavSQLWS.Views;

namespace NavSQLWS;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(InfoPage), typeof(InfoPage));
        Routing.RegisterRoute(nameof(NewPage2), typeof(NewPage2));
    }
}
