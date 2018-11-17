using Algorithms;
using Runner;
using Runner.Algorithms;
using SimpleInjector;

namespace knapsack.DependencyResolver
{
    public static class EngineModulePackage
    {
        public static void Bootstrap(Container container)
        {
            container.Register<IOptimizationAlgorithm, GreedyAlgorithm>();
            container.Register<IRunner, Runner.Runner>();
        }
    }
}