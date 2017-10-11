using System;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class DriverRouteService : IDriverRouteService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IRouteManager _routeManager;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DriverRouteService(IDriverRepository driverRepository,
            IUserRepository userRepository, IMapper mapper,
            IRouteManager routeManager)
        {
            _driverRepository = driverRepository;
            _routeManager = routeManager;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(Guid userId, string name, 
            double startLatitude, double startLongitude,
            double endLatitude, double endLongitude)
        {
            var driver = await _driverRepository.GetAsync(userId);
            if(driver == null)
            {
                throw new Exception($"Driver with user id: '{userId}' was not found.");
            }
            var startAddress = await _routeManager.GetAddressAsync(startLatitude, startLongitude);
            var endAddress = await _routeManager.GetAddressAsync(endLatitude, endLongitude);
            var startNode = Node.Create(startAddress, startLatitude, startLongitude);
            var endNode = Node.Create(endAddress, endLatitude, endLongitude);
            var distance = _routeManager.CalculateDistance(startLatitude, startLongitude,
                endLatitude, endLongitude);
            driver.AddRoute(name, startNode, endNode, distance);
            await _driverRepository.UpdateAsync(driver);
        }

        public async Task DeleteAsync(Guid userId, string name)
        {
            var driver = await _driverRepository.GetAsync(userId);
            if(driver == null)
            {
                throw new Exception($"Driver with user id: '{userId}' was not found.");
            }
            driver.DeleteRoute(name);
            await _driverRepository.UpdateAsync(driver);
        }
    }
}