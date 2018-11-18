using Algorithms;
using Algorithms.DynamicProgramming;
using Runner;
using Runner.Algorithms;
using SimpleInjector;

namespace knapsack.DependencyResolver
{
    public static class EngineModulePackage
    {
        public static void Bootstrap(Container container)
        {
            container.Collection.Register<IOptimizationAlgorithm>(typeof(GreedyAlgorithm),
                typeof(DynamicProgrammingAlgorithm));
            container.Register<IRunner, Runner.Runner>();
        }
    }
}