using System;
using System.Collections.Generic;

namespace Domain.Entities.NodeEntity
{
    public class Node : IEquatable<Node>
    {
        public int Id { get;}

        public double XCoord { get; }
        
        public double YCoord { get; }

        public List<Node> AdjacencyList { get; private set; }
        
        public bool IsColorAssigned { get; set; }

        public Node(int nodeId)
        {
            Id = nodeId;
            AdjacencyList = new List<Node>();
        }

        public Node(int nodeId, double xCoord, double yCoord)
        {
            Id = nodeId;
            XCoord = xCoord;
            this.YCoord = yCoord;
            AdjacencyList = new List<Node>();
        }

        public void AddToAdjacencyList(Node node)
        {
            AdjacencyList.Add(node);
        }

        public bool Equals(Node other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return XCoord.Equals(other.XCoord) && YCoord.Equals(other.YCoord);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (XCoord.GetHashCode() * 397) ^ YCoord.GetHashCode();
            }
        }
    }
}