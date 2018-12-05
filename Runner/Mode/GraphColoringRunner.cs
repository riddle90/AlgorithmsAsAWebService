using System.Threading.Tasks;
using Runner.Algorithms;
using Runner.IBuilder;

namespace Runner.Mode
{
    public class GraphColoringRunner : IRunner
    {
        private readonly INodeBuilder _nodeBuilder;
        private readonly IGraphColoringAlgorithm _graphColoringAlgorithm;
        private readonly IGraphColoringSolutionBuilder _solutionBuilder;

        public GraphColoringRunner(INodeBuilder nodeBuilder, IGraphColoringAlgorithm graphColoringAlgorithm, IGraphColoringSolutionBuilder solutionBuilder)
        {
            _nodeBuilder = nodeBuilder;
            _graphColoringAlgorithm = graphColoringAlgorithm;
            _solutionBuilder = solutionBuilder;
        }
        
        public async Task RunOptimization()
        {
            await _nodeBuilder.Build();
            var solution = _graphColoringAlgorithm.Optimize();
            await _solutionBuilder.WriteSolution(solution);
        }
    }
}