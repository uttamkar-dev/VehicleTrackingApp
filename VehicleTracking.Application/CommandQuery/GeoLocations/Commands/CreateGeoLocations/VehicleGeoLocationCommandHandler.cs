using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.Application.Helper;
using VehicleTracking.Application.Interfaces;
using VehicleTracking.Entity.Entities;

namespace VehicleTracking.Application.CommandQuery.GeoLocations.Commands.CreateGeoLocations
{
    public class VehicleGeoLocationCommandHandler : IRequestHandler<VehicleGeoLocationCommand, Message>
    {
        private readonly IMapper _iMapper;
        private readonly IVehicleGeoLocationRepository _iVehicleGeoLocationRepository;
        private readonly IHttpContextAccessor _iHttpContextAccessor;

        public VehicleGeoLocationCommandHandler(IMapper iMapper, IVehicleGeoLocationRepository iVehicleGeoLocationRepository, IHttpContextAccessor iHttpContextAccessor)
        {
            _iMapper = iMapper;
            _iVehicleGeoLocationRepository = iVehicleGeoLocationRepository;
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public async Task<Message> Handle(VehicleGeoLocationCommand request, CancellationToken cancellationToken)
        {
            var message = new Message();
            var vehicleGeoLocation = _iMapper.Map<VehicleGeoLocation>(request);

            var currentUser = _iHttpContextAccessor.HttpContext.User;
            var userId = currentUser.Claims.Where(c => c.Type == "Id").Select(x => x.Value).FirstOrDefault();

            // This section checks its own user id
            if (request.UserId != Convert.ToInt32(userId) && request.UserId > 0)
                return new Message()
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    StatusMessage = "You cannot add another user's geo location"
                };

            vehicleGeoLocation.UserId = Convert.ToInt32(userId);
            vehicleGeoLocation.CreatedDate = DateTime.Now;
            vehicleGeoLocation.CreatedBy = Convert.ToInt32(userId);
            var register = await _iVehicleGeoLocationRepository.AddAsync(vehicleGeoLocation);
            if (register.Id > 0)
            {
                message = new Message()
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                    StatusMessage = "Data saved successfully"
                };
            }
            return message;
        }
    }

}
