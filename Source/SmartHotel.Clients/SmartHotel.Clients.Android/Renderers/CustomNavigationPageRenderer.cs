using Android.Content;
using Android.Support.V7.Widget;
using SmartHotel.Clients.Core.Views;
using SmartHotel.Clients.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using AView = Android.Views.View;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationPageRenderer))]
namespace SmartHotel.Clients.Droid.Renderers
{
    public class CustomNavigationPageRenderer : NavigationPageRenderer
    {
        IPageController PageController => Element as IPageController;
        CustomNavigationPage CustomNavigationPage => Element as CustomNavigationPage;

        public CustomNavigationPageRenderer(Context context) : base(context)
        {
            
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            CustomNavigationPage.IgnoreLayoutChange = true;
            base.OnLayout(changed, l, t, r, b);
            CustomNavigationPage.IgnoreLayoutChange = false;

            var containerHeight = b - t;

            PageController.ContainerArea = new Rect(0, 0, Context.FromPixels(r - l), Context.FromPixels(containerHeight));

            for (var i = 0; i < ChildCount; i++)
            {
                var child = GetChildAt(i);

                if (child is Toolbar)
                {
                    continue;
                }

                child.Layout(0, 0, r, b);
            }
        }
    }
}