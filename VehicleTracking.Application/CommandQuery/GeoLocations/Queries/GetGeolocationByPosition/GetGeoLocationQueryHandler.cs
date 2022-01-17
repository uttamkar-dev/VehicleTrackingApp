using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using VehicleTracking.Application.Interfaces;

namespace VehicleTracking.Application.CommandQuery.GeoLocations.Queries.GetGeolocationByPosition
{
    public class GetGeoLocationQueryHandler : IRequestHandler<GetGeoLocationQuery, string>
    {
        private readonly IVehicleGeoLocationRepository _iVehicleGeoLocationRepository;

        public GetGeoLocationQueryHandler(IVehicleGeoLocationRepository iVehicleGeoLocationRepository)
        {
            _iVehicleGeoLocationRepository = iVehicleGeoLocationRepository;
        }
        public async Task<string> Handle(GetGeoLocationQuery request, CancellationToken cancellationToken)
        {
            return await _iVehicleGeoLocationRepository.GetGeoLocationByPositionAsync(request.latitude, request.longitude);
        }
    }
}
