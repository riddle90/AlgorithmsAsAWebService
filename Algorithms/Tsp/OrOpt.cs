using System.Collections.Generic;
using System.Linq;
using Domain.Entities.NodeEntity;
using Domain.Entities.RouteEntity;

namespace Algorithms.Tsp
{
    public class OrOpt : IOrOpt
    {
        private IRouteRepository _routeRepository;
        private ICostCalculator _costCalculator;

        public OrOpt(IRouteRepository routeRepository, ICostCalculator costCalculator)
        {
            _routeRepository = routeRepository;
            _costCalculator = costCalculator;
        }
        
        public bool Optimize()
        {
            var route = _routeRepository.GetAllRoutes().First();

            bool improvementFound = false;
            int numberOfIterationsWithoutImprovement = 0;
            int numberOfIterations = 0;

            while (numberOfIterationsWithoutImprovement==0 && numberOfIterations <= 3)
            {
                numberOfIterationsWithoutImprovement++;
                numberOfIterations++;
                for (int i = 0; i < route.Nodes.Count - 1; i++)
                {
                    for (int j = 1; j < route.Nodes.Count; j++)
                    {
                        var cost = this.CalculateCost(route, i, j);

                        if (cost < -0.0001)
                        {
                            numberOfIterationsWithoutImprovement = 0;
                            improvementFound = true;

                            var newOrder = this.GetNewOrder(route, i, j);
                            route.UpdateRoute(newOrder, route.Cost + cost);
                            
                            break;
                        }
                    }
                }
            }

            return improvementFound;
        }

        private IEnumerable<Node> GetNewOrder(Route route, int i, int j)
        {
            if (i < j)
            {
                return route.Nodes.Take(i).Union(route.Nodes.Skip(i + 1).Take(j - i).Append(route.Nodes[i])
                    .Union(route.Nodes.Skip(j + 1)));
            }
            else
            {
                return route.Nodes.Take(j + 1).Append(route.Nodes[i]).Union(route.Nodes.Skip(j + 1).Take(i - (j+1)))
                    .Union(route.Nodes.Skip(i + 1));
            }
        }

        private double CalculateCost(Route route, int i, int j)
        {
            double cost = 0;

            if (i == j + 1 || i == j)
            {
                return cost;
            }
            
            if (i == 0 && j == route.Nodes.Count - 1)
            {
                cost = 0;
            }
            else if (i == 0)
            {
                cost += _costCalculator.GetCost(route.Nodes[route.Nodes.Count - 1], route.Nodes[i + 1])
                        + _costCalculator.GetCost(route.Nodes[j], route.Nodes[i])
                        + _costCalculator.GetCost(route.Nodes[i], route.Nodes[j + 1])
                        - _costCalculator.GetCost(route.Nodes[route.Nodes.Count - 1], route.Nodes[i])
                        - _costCalculator.GetCost(route.Nodes[i], route.Nodes[i + 1])
                        - _costCalculator.GetCost(route.Nodes[j], route.Nodes[j + 1]);
            }
            else if (j == route.Nodes.Count - 1)
            {
                cost += _costCalculator.GetCost(route.Nodes[i - 1], route.Nodes[i + 1])
                        + _costCalculator.GetCost(route.Nodes[j], route.Nodes[i])
                        + _costCalculator.GetCost(route.Nodes[i], route.Nodes[0])
                        - _costCalculator.GetCost(route.Nodes[i - 1], route.Nodes[i])
                        - _costCalculator.GetCost(route.Nodes[i], route.Nodes[i + 1])
                        - _costCalculator.GetCost(route.Nodes[j], route.Nodes[0]);
            }
            else
            {
                cost += _costCalculator.GetCost(route.Nodes[i - 1], route.Nodes[i + 1])
                        + _costCalculator.GetCost(route.Nodes[j], route.Nodes[i])
                        + _costCalculator.GetCost(route.Nodes[i], route.Nodes[j + 1])
                        - _costCalculator.GetCost(route.Nodes[i - 1], route.Nodes[i])
                        - _costCalculator.GetCost(route.Nodes[i], route.Nodes[i + 1])
                        - _costCalculator.GetCost(route.Nodes[j], route.Nodes[j + 1]);
            }

            return cost;
        }
    }
}