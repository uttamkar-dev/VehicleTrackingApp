using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using VehicleTracking.Application.CommandQuery.Accounts.Command.CreateAccounts;
using VehicleTracking.Application.CommandQuery.Accounts.Queries.Login;

namespace VehicleTrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _iMediator;

        public AccountsController(IMediator iMediator)
        {
            _iMediator = iMediator;
        }

        [HttpPost("createuser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateUser([FromBody] UserAccountCommand command) => Ok(await _iMediator.Send(command));


        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Login([FromBody] LoginCommand command)
        {
            var token = await _iMediator.Send(command);
            return Ok(token);
        }
    }
}
