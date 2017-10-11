using System;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class DeleteDriverRoute : AuthenticateCommandBase
    {
        public string Name { get; set; }
    } 
}