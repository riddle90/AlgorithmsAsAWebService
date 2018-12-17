using System.Collections.Generic;
using Domain.Entities.NodeEntity;
using Domain.Entities.RouteEntity;

namespace Algorithms.Tsp
{
    public interface IBestInsertion
    {
        IEnumerable<Node> AddNodeToRoute(Node node, IReadOnlyList<Node> stops, out double changeInCost);
    }
}