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
            container.Register<IOptimizationAlgorithm, DynamicProgrammingAlgorithm>();
            container.Register<IRunner, Runner.Runner>();
        }
    }
}