using Runner.Algorithms;
using Runner.Mode;
using SimpleInjector;

namespace GraphColoring.DependencyResolver
{
    public static class EngineModulePackage
    {
        public static void Bootstrap(Container container)
        {
           
            container.Register<IRunner, GraphColoringRunner>();
        }
    }
}