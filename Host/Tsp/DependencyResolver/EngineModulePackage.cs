using Algorithms.GraphColoringCP;
using Algorithms.Tsp;
using Runner.Algorithms;
using Runner.Mode;
using SimpleInjector;

namespace Tsp.DependencyResolver
{
    public static class EngineModulePackage
    {
        public static void Bootstrap(Container container)
        {
           
            container.Register<IRunner, TspRunner>();
            container.Register<ISequenceOptimizer, SequenceOptimizer>();
            container.Register<ITwoOpt, TwoOpt>();
            container.Register<IOrOpt, OrOpt>();
            container.Register<IBestInsertion, BestInsertion>();
            container.Register<ICostCalculator, CostCalculator>();
            container.Register<IConstructionAlgorithm, ConstructionWithBestInsertion>();
        }
    }
}