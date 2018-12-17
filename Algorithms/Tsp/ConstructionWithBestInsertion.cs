using System.Collections.Generic;
using System.Linq;
using Domain.Entities.NodeEntity;
using Domain.Entities.RouteEntity;

namespace Algorithms.Tsp
{
    public class ConstructionWithBestInsertion : IConstructionAlgorithm
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IBestInsertion _bestInsertion;
        private readonly INodeAndArcRepository _nodeAndArcRepository;

        public ConstructionWithBestInsertion(IRouteRepository routeRepository, IBestInsertion bestInsertion,
            INodeAndArcRepository nodeAndArcRepository, ICostCalculator costCalculator)
        {
            _routeRepository = routeRepository;
            _bestInsertion = bestInsertion;
            _nodeAndArcRepository = nodeAndArcRepository;
        }

        public void CreateRoute()
        {
            Route route = null;
            foreach (var node in _nodeAndArcRepository.GetAllNodes())
            {
                if (route == null)
                {
                    route = new Route(new List<Node> {node});
                    _routeRepository.AddRoute(route);
                }
                else
                {
                    var stops = _bestInsertion.AddNodeToRoute(node, route.Nodes, out double changeInCost);
                    route.UpdateRoute(stops, route.Cost + changeInCost);
                }
            }
        }
    }
}