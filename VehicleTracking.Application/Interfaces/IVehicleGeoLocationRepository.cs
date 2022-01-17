using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Entity.Entities;

namespace VehicleTracking.Application.Interfaces
{
    public interface IVehicleGeoLocationRepository : IAsyncRepository<VehicleGeoLocation>
    {
        Task<IEnumerable<VehicleGeoLocation>> GetAllByTimeAsync(int userId, DateTime fromDate, DateTime toDate);
        Task<IEnumerable<VehicleGeoLocation>> GetAllByUserAsync(int userId);
        Task<string> GetGeoLocationByPositionAsync(string latitude, string longitude);
    }
}
