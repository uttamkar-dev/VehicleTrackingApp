using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using VehicleTracking.Application.CommandQuery.Accounts.Command.CreateAccounts;
using VehicleTracking.Application.CommandQuery.Accounts.Queries.Login;
using VehicleTracking.Application.CommandQuery.GeoLocations.Commands.CreateGeoLocations;
using VehicleTracking.Application.CommandQuery.GeoLocations.Queries.GetGeolocationByPosition;
using VehicleTracking.Application.CommandQuery.GeoLocations.Queries.GetGeoLocationByTime;
using VehicleTracking.Application.CommandQuery.GeoLocations.Queries.GetGeoLocationByUser;
using VehicleTracking.Application.CommandQuery.GeoLocations.Queries.GetGeoLocations;
using VehicleTracking.Entity.Dtos;

namespace VehicleTrackingApi.Controllers
{
    public class VehicleGeoLocationController : BaseController
    {
        private readonly IMediator _iMediator;

        public VehicleGeoLocationController(IMediator iMediator)
        {
            _iMediator = iMediator;
        }

        [HttpPost("create-vehicle-geolocation")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateAsync(VehicleGeoLocationCommand command) => Ok(await _iMediator.Send(command));

        [HttpGet("getall")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAllAsync() => Ok(await _iMediator.Send(new GetGeoLocationListQuery()));

        [HttpGet("getall-by-time")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAllByTimeAsync(RequestDto entity) => Ok(await _iMediator.Send(new GetGeoLocationByTimeQuery(entity.UserId, entity.FromDate, entity.ToDate)));

        [HttpGet("getall-by-user/{userId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAllByUserAsync(int userId) => Ok(await _iMediator.Send(new GetGeoLocationByUserQuery(userId)));

        [HttpGet("get-geolocation")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetGeoLocationAsync(GeolocationDto entity) => Ok(await _iMediator.Send(new GetGeoLocationQuery(entity.Latitude, entity.Longitude)));
    }
}
