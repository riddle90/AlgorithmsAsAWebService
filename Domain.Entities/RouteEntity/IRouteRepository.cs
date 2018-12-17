using System.Collections.Generic;

namespace Domain.Entities.RouteEntity
{
    public interface IRouteRepository
    {
        void AddRoute(Route route);

        IEnumerable<Route> GetAllRoutes();
    }
}