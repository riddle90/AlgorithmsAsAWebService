using Domain.Entities.NodeEntity;
using Domain.Entities.RouteEntity;

namespace Algorithms.Tsp
{
    public interface ICostCalculator
    {
        double GetCost(Node node1, Node node2);

        double CalculateRouteCost(Route route);
    }
}