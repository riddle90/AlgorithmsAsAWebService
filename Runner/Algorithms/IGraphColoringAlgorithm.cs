using Domain.Entities.NodeEntity;

namespace Runner.Algorithms
{
    public interface IGraphColoringAlgorithm
    {
        IGraphColoringSolution Optimize();
    }
}