using System;

namespace Passenger.Infrastructure.Commands
{
    public class AuthenticateCommandBase : IAuthenticatedCommand 
    {
        public Guid UserId { get; set; }   
    }
}