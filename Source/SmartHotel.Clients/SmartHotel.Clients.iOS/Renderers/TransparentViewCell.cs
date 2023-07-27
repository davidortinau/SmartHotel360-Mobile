using SmartHotel.Clients.iOS.Renderers;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

[assembly: ExportRenderer(typeof(ViewCell), typeof(TransparentViewCell))]
namespace SmartHotel.Clients.iOS.Renderers
{
    public class TransparentViewCell : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);

            if (cell != null)
            {
                cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            }

            return cell;
        }
    }
}