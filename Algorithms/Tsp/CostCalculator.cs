using System;
using Domain.Entities.NodeEntity;
using Domain.Entities.RouteEntity;

namespace Algorithms.Tsp
{
    public class CostCalculator : ICostCalculator
    {
        public double GetCost(Node node1, Node node2)
        {
            return Math.Sqrt(Math.Pow(node1.XCoord - node2.XCoord, 2) + Math.Pow(node1.YCoord - node2.YCoord, 2));
        }

        public double CalculateRouteCost(Route route)
        {
            double cost = 0;
            for (int i = 0; i < route.Nodes.Count; i++)
            {
                if (i == route.Nodes.Count - 1)
                {
                    cost += GetCost(route.Nodes[i], route.Nodes[0]);
                }
                else
                {
                    cost += GetCost(route.Nodes[i], route.Nodes[i + 1]);
                }
            }

            return cost;
        }
    }
}