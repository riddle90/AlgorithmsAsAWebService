using System.Reflection;
using Algorithms.DynamicProgramming;
using Runner.Algorithms;

namespace Algorithms
{
    public static class AlgorithmPicker
    {
        public static bool ShouldRunOnThisDataSet(IOptimizationAlgorithm optimizationAlgorithm, int count)
        {
            if (count > 200)
            {
                return optimizationAlgorithm.GetType().IsAssignableFrom(typeof(GreedyAlgorithm));
            }

            return optimizationAlgorithm.GetType().IsAssignableFrom(typeof(DynamicProgrammingAlgorithm));
        }
    }
}