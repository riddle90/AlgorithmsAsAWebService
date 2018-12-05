using System.Collections.Generic;
using System.Reflection;
using Domain.Entities.NodeEntity;
using Runner.IBuilder;

namespace Infrastructure.Repository.NodeBuilder
{
    public class NodeAndArcRepository : INodeAndArcRepository
    {
        public Dictionary<int, Node> Nodes { get; private set; }
        
        public NodeAndArcRepository()
        {
            Nodes = new Dictionary<int, Node>();
        }
        
        public void AddNode(Node node)
        {
            Nodes.Add(node.Id, node);
        }

        public void AddArc(int sourceNode, int destinationNode)
        {
            Nodes[sourceNode].AddToAdjacencyList(Nodes[destinationNode]);
            Nodes[destinationNode].AddToAdjacencyList(Nodes[sourceNode]);
        }

        public IEnumerable<Node> GetAllNodes()
        {
            return this.Nodes.Values;
        }
    }
}