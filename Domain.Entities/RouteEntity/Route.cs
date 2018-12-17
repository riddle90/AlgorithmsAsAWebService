using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.NodeEntity;

namespace Domain.Entities.RouteEntity
{
    public class Route
    {
        public Guid Id { get; private set; }
        
        public IReadOnlyList<Node> Nodes { get; private set; }

        public double Cost { get; private set; }

        public Route(List<Node> nodes)
        {
            Id = new Guid();
            Nodes = new List<Node>();
            Nodes = nodes;
            Cost = 0;
        }

        public void UpdateRoute(IEnumerable<Node> nodes, double cost)
        {
            Nodes = nodes.ToList();
            this.Cost = cost;
        }
    }
}