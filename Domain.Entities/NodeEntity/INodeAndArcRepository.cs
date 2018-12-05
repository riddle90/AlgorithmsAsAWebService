using System.Collections.Generic;

namespace Domain.Entities.NodeEntity
{
    public interface INodeAndArcRepository
    {
        void AddNode(Node node);

        void AddArc(int sourceNode, int destinationNode);

        IEnumerable<Node> GetAllNodes();

    }
}