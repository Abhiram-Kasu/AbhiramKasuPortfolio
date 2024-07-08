global using static AbhiramKasuPortfolio.App;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AbhiramKasuPortfolio.ViewModels;
using AbhiramKasuPortfolio.Views;
using AvaloniaHelpers.Navigation;

namespace AbhiramKasuPortfolio;

public partial class App : Application
{
    
    public static NavigationService NavService { get; } = new ();
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        
        NavService.RegisterView<HomeView, HomeViewModel>(nameof(HomeView));
        
        
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView();
        }

        base.OnFrameworkInitializationCompleted();

    }
}