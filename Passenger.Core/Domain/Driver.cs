using System;

namespace Passenger.Core.Domain
{
    public class Driver
    {
        public Guid UserId { get; protected set; }
        public Vehicle Vehicle { get; protected set; }
        public IEquatable<Route> Routes { get; protected set; }
        public IEquatable<DailyRoute> DailyRoutes { get; protected set; }

        protected Driver()
        {
            
        }

        public Driver(Guid userid)
        {
            UserId = UserId;
        }
    }
}
