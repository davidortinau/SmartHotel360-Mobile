using Android.Content;
using SmartHotel.Clients.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

[assembly: ExportRenderer(typeof(Slider), typeof(CustomSliderRenderer))]
namespace SmartHotel.Clients.Droid.Renderers
{
    public class CustomSliderRenderer : SliderRenderer
    {
        public CustomSliderRenderer(Context context) : base(context)
        {
            
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);

            Control?.SetPadding(0, 0, 0, 0);
        }
    }
}