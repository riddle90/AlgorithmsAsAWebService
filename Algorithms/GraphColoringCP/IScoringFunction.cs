using Domain.Entities.NodeEntity;

namespace Algorithms.GraphColoringCP
{
    public interface IScoringFunction
    {
        void UpdateScore(Node selectedNode, DomainStore domainStore);
    }
}