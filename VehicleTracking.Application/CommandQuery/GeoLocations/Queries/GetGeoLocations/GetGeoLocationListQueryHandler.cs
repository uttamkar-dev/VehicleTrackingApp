using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.Application.Interfaces;
using VehicleTracking.Entity.Dtos;

namespace VehicleTracking.Application.CommandQuery.GeoLocations.Queries.GetGeoLocations
{
    public class GetGeoLocationListQueryHandler : IRequestHandler<GetGeoLocationListQuery, List<VehicleGeoLocationDto>>
    {
        private readonly IMapper _iMapper;
        private readonly IVehicleGeoLocationRepository _iVehicleGeoLocationRepository;

        public GetGeoLocationListQueryHandler(IMapper iMapper, IVehicleGeoLocationRepository iVehicleGeoLocationRepository)
        {
            _iMapper = iMapper;
            _iVehicleGeoLocationRepository = iVehicleGeoLocationRepository;
        }
        public async Task<List<VehicleGeoLocationDto>> Handle(GetGeoLocationListQuery request, CancellationToken cancellationToken)
        {
            var itemObj = await _iVehicleGeoLocationRepository.GetAllAsync();
            var items = itemObj.ToList();
            return _iMapper.Map<List<VehicleGeoLocationDto>>(items);
        }
    }
}
