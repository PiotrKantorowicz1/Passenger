using System;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class CreateDriver : ICommand
    {
        public Guid UserId { get; set; }
        public DriverVehicle Vehicle { get; set; }
    }

    public class DriverVehicle
    {
        public Guid Brand { get; protected set; }
        public Guid Name { get; protected set; }
        public Guid Seats { get; protected set; }
    }
}
