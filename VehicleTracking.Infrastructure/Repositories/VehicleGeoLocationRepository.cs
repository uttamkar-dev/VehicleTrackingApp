using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using VehicleTracking.Application.Interfaces;
using VehicleTracking.Entity.Entities;
using VehicleTracking.Infrastructure.Context;

namespace VehicleTracking.Infrastructure.Repositories
{
    public class VehicleGeoLocationRepository : RepositoryBase<VehicleGeoLocation>, IVehicleGeoLocationRepository
    {
        public VehicleGeoLocationRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<VehicleGeoLocation>> GetAllByTimeAsync(int userId, DateTime fromDate, DateTime toDate)
        {
            return await _context.VehicleGeoLocations.Where(x => x.UserId == userId && (x.TrackingDate >= fromDate && x.TrackingDate <= toDate)).ToListAsync();
        }

        public async Task<IEnumerable<VehicleGeoLocation>> GetAllByUserAsync(int userId)
{
            return await _context.VehicleGeoLocations.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<string> GetGeoLocationByPositionAsync(string latitude, string longitude)
        {
            string locationName = string.Empty;

            if (string.IsNullOrEmpty(longitude) || string.IsNullOrEmpty(latitude))
                return "";

            string url = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false", latitude, longitude);

            using (var client = new HttpClient())
            {
                var request = await client.GetAsync(url);
                var content = await request.Content.ReadAsStringAsync();
                var xmlDocument = XDocument.Parse(content);

            }
            return locationName;
        }
    }
}
