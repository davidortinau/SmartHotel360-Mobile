using SmartHotel.Clients.Core.Models;
using System.Threading.Tasks;
using Microsoft.Maui.Devices.Sensors;

namespace SmartHotel.Clients.Core.Services.Geolocator
{
    public interface ILocationService
    {
        Task<Location> GetPositionAsync();
    }
}