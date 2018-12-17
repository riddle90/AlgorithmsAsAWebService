using System.Threading.Tasks;
using Runner.Algorithms;
using Runner.IBuilder;

namespace Runner.Mode
{
    public class TspRunner : IRunner
    {
        private readonly INodeBuilder _nodeBuilder;
        private readonly ISequenceOptimizer _sequenceOptimizer;
        private readonly ISolutionBuilder _solutionBuilder;

        public TspRunner(INodeBuilder nodeBuilder, ISequenceOptimizer sequenceOptimizer, ISolutionBuilder solutionBuilder)
        {
            _nodeBuilder = nodeBuilder;
            _sequenceOptimizer = sequenceOptimizer;
            _solutionBuilder = solutionBuilder;
        }
        
        public async Task RunOptimization()
        {
            await _nodeBuilder.Build();
            _sequenceOptimizer.RunOptimization();
            await _solutionBuilder.WriteSolution();
        }
    }
}