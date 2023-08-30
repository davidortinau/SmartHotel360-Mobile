using System;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Platform;
using FFImageLoading.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using SmartHotel.Clients.Core;
using SmartHotel.Clients.Core.Controls;
using SmartHotel.Clients.Core.Effects;
using SmartHotel.Clients.Core.Helpers;
using SmartHotel.Clients.Core.Services.Authentication;
using SmartHotel.Clients.Core.Services.DismissKeyboard;
using SmartHotel.Clients.Core.ViewModels.Base;
using SmartHotel.Clients.iOS.Renderers;
using SmartHotel.Clients.iOS.Services;
using SmartHotel.Clients.iOS.Services.DismissKeyboard;
using UIKit;

namespace SmartHotel.Clients.iOS;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseSharedMauiApp()
            .ConfigureEffects(effects =>
            {
                effects.Add<UnderlineTextEffect, SmartHotel.Clients.iOS.Effects.UnderlineTextEffect>();
            })
            .ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler(typeof(CalendarButton), typeof(CalendarButtonHandler));
                handlers.AddHandler(typeof(ViewCell), typeof(TransparentViewCell));
                handlers.AddHandler(typeof(ExtendedEntry), typeof(ExtendedEntryHandler));
                handlers.AddHandler(typeof(CustomMap), typeof(CustomMapHandler));
            });

        PlatformStyling();
        
        Locator.Instance.Register<IDismissKeyboardService, DismissKeyboardService>();
        Locator.Instance.Register<IBrowserCookiesService, BrowserCookiesService>();
        
        StatusBar.SetStyle(StatusBarStyle.LightContent);
        StatusBarHelper.Instance.MakeTranslucentStatusBar(true);

        return builder.Build();
    }

    static void PlatformStyling()
    {
        UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
        UINavigationBar.Appearance.ShadowImage = new UIImage();
        UINavigationBar.Appearance.BackgroundColor = UIColor.Clear;
        UINavigationBar.Appearance.TintColor = UIColor.White;
        UINavigationBar.Appearance.BarTintColor = UIColor.Clear;
        UINavigationBar.Appearance.Translucent = true;
        
        

        // Initialize B2C client
        // App.AuthenticationClient.PlatformParameters = new PlatformParameters(UIApplication.SharedApplication.KeyWindow.RootViewController);
    }
    
}
