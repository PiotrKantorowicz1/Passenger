using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Passenger.Infrastructure.Commands.Users;
using Xunit;
using Passenger.Infrastructure.DTO;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class UsersControllerTests : ControllerTestBase
    {     
       [Fact]
        public async Task given_valid_email_user_should_exist()
        {
            var email = "user1@gmail.com";
            var user = await GetUserAsync(email);
            user.Email.ShouldBeEquivalentTo(email);
        }

        [Fact]
        public async Task given_valid_email_user_should_not_exist()
        {
            var email = "user1@gmail.com";
            var response = await Client.GetAsync($"users/{email}");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            var command = new CreateUser
            {
                Email = "test@gmail.com",
                Username = "test.",
                Password = "secret"
            };
            var payload = GetPayLoad(command);
            var response = await Client.GetAsync($"users/{payload}");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"users/{command.Email}.");

            var user = await GetUserAsync(command.Email);
            user.Email.ShouldBeEquivalentTo(command.Email);
        }

        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"users/{email}");
            var responeString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDto>(responeString);
        }
    }
}
