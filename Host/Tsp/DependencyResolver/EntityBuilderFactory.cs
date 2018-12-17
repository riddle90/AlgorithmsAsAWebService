using Infrastructure.Repository.NodeBuilder;
using Infrastructure.Repository.SolutionBuilder;
using Infrastructure.Repository.TspNodeBuilder;
using Runner.IBuilder;
using SimpleInjector;

namespace Tsp.DependencyResolver
{
    public static class EntityBuilderFactory
    {
        public static void Bootstrap(Container container)
        {
            
            container.Register<ISolutionBuilder, TspSolutionWriter>();
            container.Register<INodeBuilder, TspNodeBuilder>();
        }
    }
}