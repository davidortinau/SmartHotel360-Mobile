using SmartHotel.Clients.Core.Controls;
using SmartHotel.Clients.UWP.Extensions;
using SmartHotel.Clients.UWP.Renderers;
using System.ComponentModel;
using System.Linq;
using Microsoft.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace SmartHotel.Clients.UWP.Renderers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        public ExtendedEntry ExtendedEntryElement => Element as ExtendedEntry;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control != null)
                {
                    Control.Style = App.Window.Resources["FormTextBoxStyle"] as Windows.UI.Xaml.Style;
                }

                Control.Loaded -= OnControlLoaded;
                Control.Loaded += OnControlLoaded;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals(nameof(ExtendedEntry.LineColor)))
            {
                UpdateLineColor();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null)
            {
                Control.Loaded -= OnControlLoaded;
            }

            base.Dispose(disposing);
        }

        void UpdateLineColor()
        {
            var border = Control.FindVisualChildren<Border>()      
                .Where(c => c.Name == "BorderElement")
                .FirstOrDefault();

            if (border != null)
            {
                border.BorderBrush = new SolidColorBrush(ExtendedEntryElement.LineColor.ToUwp());
            }
        }

        void OnControlLoaded(object sender, RoutedEventArgs e) => UpdateLineColor();
    }
}
