using System;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
    public class Node
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        public string Address { get; protected set; }
        public string Longitude { get; protected set; }
        public double Latitude { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public Node()
        {

        }

        protected Node (string address, double longtitude, double latitude)
        {
            SetAdress(address);
            SetLongtitude(longtitude);
            SetLatitute(latitude);
        }

        public void SetAdress(string address)
        {
            if (!NameRegex.IsMatch(address))
            {
                throw new Exception("Adress id inValid.");
            }

            Address = address;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetLongtitude(double longtitude)
        {
            if (double.IsNaN(longtitude))
            {
                throw new Exception("Longtitude must be a number.");
            }
        }

        public void SetLatitute(double latitude)
        {
            if (double.IsNaN(latitude))
            {
                throw new Exception("Latitude must be a number.");
            }
            if (Latitude == latitude)
            {
                return;
            }

            Latitude = latitude;
            UpdatedAt = DateTime.UtcNow;
    }

        public static Node Create(string address, double longitude, double latitude)
           => new Node(address, longitude, latitude);
}
}
