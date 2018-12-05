using System.Collections.Generic;
using System.Threading.Tasks;
using Runner.Algorithms;
using Runner.IBuilder;

namespace Runner.Mode
{
    public class KnapsackRunner : IRunner
    {
        private readonly IBagBuilder _bagBuilder;
        private readonly IItemBuilder _itemBuilder;
        private readonly IEnumerable<IOptimizationAlgorithm> _optimizationAlgorithm;
        private readonly IKnapsackSolutionBuilder _solutionBuilder;

        public KnapsackRunner(IBagBuilder bagBuilder, IItemBuilder itemBuilder, IEnumerable<IOptimizationAlgorithm> optimizationAlgorithm, IKnapsackSolutionBuilder solutionBuilder)
        {
            _bagBuilder = bagBuilder;
            _itemBuilder = itemBuilder;
            _optimizationAlgorithm = optimizationAlgorithm;
            _solutionBuilder = solutionBuilder;
        }
        
        public async Task RunOptimization()
        {
            await _bagBuilder.Build();
            await _itemBuilder.Build();

            foreach (var optimizationAlgorithm in _optimizationAlgorithm)
            {
                optimizationAlgorithm.Optimize();
            }

            await _solutionBuilder.WriteSolution();
        }
    }
}