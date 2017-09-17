using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]
    public class AccountController : ApiControllerBase
    {          
        public AccountController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [HttpPost]
        [Route("password")]
        public async Task<IActionResult> Post([FromBody] ChangeUserPassword command)
        {
            await CommandDispatcher.DispatcherAsync(command);

            return NoContent();
        }
    }
}
