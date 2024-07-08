using System;
using System.Threading.Tasks;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;

namespace AbhiramKasuPortfolio.Views;

public partial class MainView : UserControl
{

    private readonly Animation _slideOutAnimation;
    private readonly Animation _fadeInAnimation;
    public MainView()
    {
        InitializeComponent();
        
        _slideOutAnimation = new()
        {
            Duration = TimeSpan.FromSeconds(0.5),
            Children =
            {
                new KeyFrame()
                {
                    Setters =
                    {
                        new Setter(TranslateTransform.XProperty, this.Width)
                    },
                    Cue = new Cue(1.0)
                    
                }
            }
        };
        
        _fadeInAnimation = new()
        {
            Duration = TimeSpan.FromSeconds(0.5),
            Children =
            {
                new KeyFrame
                {
                    Setters =
                    {
                        new Setter(OpacityProperty, 1)
                    },
                    Cue = new Cue(1.0)
                }
            }
        };
        NavService.OnViewChanged += async vvModel =>
        {
            if (NavService.CurrentVVModel is { } currentVVmodel)
            {
                await _slideOutAnimation.RunAsync(currentVVmodel.View);
            }
            MainContentControl.Content = vvModel.View;
            await _fadeInAnimation.RunAsync(vvModel.View);
        };
        
        NavService.NavigateToAsync(nameof(HomeView)).Wait();

        
    }
    

}