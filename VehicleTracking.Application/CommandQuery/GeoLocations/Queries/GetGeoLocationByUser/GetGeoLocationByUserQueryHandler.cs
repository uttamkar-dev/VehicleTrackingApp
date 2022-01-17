using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.Application.Interfaces;
using VehicleTracking.Entity.Dtos;

namespace VehicleTracking.Application.CommandQuery.GeoLocations.Queries.GetGeoLocationByUser
{
    public class GetGeoLocationByUserQueryHandler : IRequestHandler<GetGeoLocationByUserQuery, List<VehicleGeoLocationDto>>
    {
        private readonly IMapper _iMapper;
        private readonly IVehicleGeoLocationRepository _iVehicleGeoLocationRepository;
        private readonly IHttpContextAccessor _iHttpContextAccessor;

        public GetGeoLocationByUserQueryHandler(IMapper iMapper, IVehicleGeoLocationRepository iVehicleGeoLocationRepository, IHttpContextAccessor iHttpContextAccessor)
        {
            _iMapper = iMapper;
            _iVehicleGeoLocationRepository = iVehicleGeoLocationRepository;
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public async Task<List<VehicleGeoLocationDto>> Handle(GetGeoLocationByUserQuery request, CancellationToken cancellationToken)
        {
            var items = await _iVehicleGeoLocationRepository.GetAllByUserAsync(request.userId);
            return _iMapper.Map<List<VehicleGeoLocationDto>>(items);
        }
    }
}
