using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Application.Helper;

namespace VehicleTracking.Application.CommandQuery.Accounts.Queries.Login
{
    public record LoginCommand(string UserName, string Password)
   : IRequest<string>;
}
