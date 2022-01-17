using MediatR;

namespace VehicleTracking.Application.CommandQuery.GeoLocations.Queries.GetGeolocationByPosition
{
    public record GetGeoLocationQuery(string latitude, string longitude) : IRequest<string>;
}
