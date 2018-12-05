using System.Collections.Generic;

namespace Domain.Entities.NodeEntity
{
    public class Node
    {
        public int Id { get; private set; }

        public List<Node> AdjacencyList { get; private set; }
        
        public bool IsColorAssigned { get; set; }

        public Node(int nodeId)
        {
            Id = nodeId;
            AdjacencyList = new List<Node>();
            IsColorAssigned = false;
        }

        public void AddToAdjacencyList(Node node)
        {
            AdjacencyList.Add(node);
        }
    }
}