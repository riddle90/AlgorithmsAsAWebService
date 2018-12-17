using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Domain.Entities.NodeEntity;
using Domain.Entities.RouteEntity;

namespace Algorithms.Tsp
{
    public class TwoOpt : ITwoOpt
    {
        private readonly IRouteRepository _routeRepository;
        private readonly ICostCalculator _costCalculator;

        public TwoOpt(IRouteRepository routeRepository, ICostCalculator costCalculator)
        {
            _routeRepository = routeRepository;
            _costCalculator = costCalculator;
        }
        
        public bool Optimize()
        {
            var route = _routeRepository.GetAllRoutes().First();

            bool improvementFound = false;
            int iterationWithoutImprovement = 0;
            int numIterations = 0;
            
            while (iterationWithoutImprovement == 0 && numIterations <= 3)
            {
                iterationWithoutImprovement++;
                numIterations++;
                for (int i = 0; i < route.Nodes.Count; i++)
                {
                    for (int j = i + 1 ; j < route.Nodes.Count; j++)
                    {
                        var cost = this.CalculateSwapCost(route, i, j);
                        if (cost < -0.0001)
                        {
                            var newOrder =  this.GetNewOrder(route, i, j);
                            route.UpdateRoute(newOrder, route.Cost + cost);
                            improvementFound = true;
                            iterationWithoutImprovement = 0;
                            break;
                        }
                    }
                }
            }
            
            return improvementFound;
        }

        private IEnumerable<Node> GetNewOrder(Route route, int i, int j)
        {
            return route.Nodes.Take(i + 1).Union(route.Nodes.Skip(i + 1).Take(j - i).Reverse())
                .Union(route.Nodes.Skip(j + 1));
        }

        private double CalculateSwapCost(Route route, int i, int j)
        {
            double cost = 0;
            if (j == route.Nodes.Count - 1)
            {
                cost += _costCalculator.GetCost(route.Nodes[i], route.Nodes[j])
                        + _costCalculator.GetCost(route.Nodes[i + 1], route.Nodes[0])
                        - _costCalculator.GetCost(route.Nodes[i], route.Nodes[i + 1])
                        - _costCalculator.GetCost(route.Nodes[j], route.Nodes[0]);
            }
            else
            {
                cost += _costCalculator.GetCost(route.Nodes[i], route.Nodes[j])
                        + _costCalculator.GetCost(route.Nodes[i + 1], route.Nodes[j + 1])
                        - _costCalculator.GetCost(route.Nodes[i], route.Nodes[i + 1])
                        - _costCalculator.GetCost(route.Nodes[j], route.Nodes[j + 1]);
            }

            return cost;
        }
    }
}