using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.Application.CommandQuery.GeoLocations.Queries.GetGeoLocations;
using VehicleTracking.Application.Interfaces;
using VehicleTracking.Entity.Dtos;

namespace VehicleTracking.Application.CommandQuery.GeoLocations.Queries.GetGeoLocationByTime
{
    public class GetGeoLocationByTimeQueryHandler : IRequestHandler<GetGeoLocationByTimeQuery, List<VehicleGeoLocationDto>>
    {
        private readonly IMapper _iMapper;
        private readonly IVehicleGeoLocationRepository _iVehicleGeoLocationRepository;
        public GetGeoLocationByTimeQueryHandler(IMapper iMapper, IVehicleGeoLocationRepository iVehicleGeoLocationRepository)
        {
            _iMapper = iMapper;
            _iVehicleGeoLocationRepository = iVehicleGeoLocationRepository;
        }
        public async Task<List<VehicleGeoLocationDto>> Handle(GetGeoLocationByTimeQuery request, CancellationToken cancellationToken)
        {
            var items = await _iVehicleGeoLocationRepository.GetAllByTimeAsync(request.userId, request.fromDate, request.toDate);
            return _iMapper.Map<List<VehicleGeoLocationDto>>(items);
        }
    }
}
