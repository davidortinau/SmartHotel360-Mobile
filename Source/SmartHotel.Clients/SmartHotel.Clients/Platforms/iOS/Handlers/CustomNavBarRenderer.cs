using System;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using UIKit;

namespace SmartHotel.Clients.Platforms.iOS.Handlers;

public class CustomNavBarRenderer : NavigationRenderer
{
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
        UINavigationBar.Appearance.ShadowImage = new UIImage();
        UINavigationBar.Appearance.BackgroundColor = UIColor.Clear;
        UINavigationBar.Appearance.TintColor = UIColor.White;
        UINavigationBar.Appearance.BarTintColor = UIColor.Clear;
        UINavigationBar.Appearance.Translucent = true;
        UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
        {
            Font = UIFont.FromName("HelveticaNeue-Light", (nfloat)20f),
            TextColor = UIColor.White
        });
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
        }

        base.Dispose(disposing);
    }
}

