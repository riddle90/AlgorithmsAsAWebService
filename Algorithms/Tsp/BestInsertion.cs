using System.Collections.Generic;
using System.Linq;
using Domain.Entities.NodeEntity;

namespace Algorithms.Tsp
{
    public class BestInsertion : IBestInsertion
    {
        private readonly ICostCalculator _costCalculator;

        public BestInsertion(ICostCalculator costCalculator)
        {
            _costCalculator = costCalculator;
        }
        
        public IEnumerable<Node> AddNodeToRoute(Node node, IReadOnlyList<Node> stops, out double changeInCost)
        {
            int numStops = stops.Count;
            double bestCost = int.MaxValue;
            int bestInsertion = -1;
            for (int i = 0; i < numStops; i++)
            {
                double cost;
                if (i == 0 || i == numStops - 1)
                {
                    cost = _costCalculator.GetCost(stops[numStops - 1], node) +
                           _costCalculator.GetCost(node, stops[0]) -
                           _costCalculator.GetCost(stops[0], stops[numStops - 1]);
                }
                else
                {
                    cost = _costCalculator.GetCost(stops[i - 1], node) + _costCalculator.GetCost(node, stops[i]) -
                           _costCalculator.GetCost(stops[i - 1], stops[i]);
                }

                if (cost < bestCost)
                {
                    bestInsertion = i;
                    bestCost = cost;
                }
            }

            changeInCost = bestCost;
            return stops.Take(bestInsertion).Append(node).Union(stops.Skip(bestInsertion));
        }
    }
}