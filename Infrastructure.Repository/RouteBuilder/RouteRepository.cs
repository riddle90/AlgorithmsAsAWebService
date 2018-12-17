using System;
using System.Collections.Generic;
using Domain.Entities.RouteEntity;

namespace Infrastructure.Repository.RouteBuilder
{
    public class RouteRepository : IRouteRepository
    {
        public Dictionary<Guid, Route> Routes { get; private set; }
        
        public RouteRepository()
        {
            Routes = new Dictionary<Guid, Route>();
        }
        
        public void AddRoute(Route route)
        {
            Routes.Add(route.Id, route);
        }

        public IEnumerable<Route> GetAllRoutes()
        {
            return Routes.Values;
        }
    }
}