using System;
using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using SmartHotel.Clients.Core;
using SmartHotel.Clients.Core.Controls;
using SmartHotel.Clients.Core.Effects;
using SmartHotel.Clients.Core.Services.Authentication;
using SmartHotel.Clients.Core.Services.DismissKeyboard;
using SmartHotel.Clients.Core.ViewModels.Base;
using SmartHotel.Clients.iOS.Renderers;
using SmartHotel.Clients.iOS.Services;
using SmartHotel.Clients.iOS.Services.DismissKeyboard;

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

        // do platform specific stuff here
        Locator.Instance.Register<IDismissKeyboardService, DismissKeyboardService>();
        Locator.Instance.Register<IBrowserCookiesService, BrowserCookiesService>();

        return builder.Build();
    }
}
