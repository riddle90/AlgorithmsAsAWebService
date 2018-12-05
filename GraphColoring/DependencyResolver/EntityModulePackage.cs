using Algorithms.GraphColoringCP;
using Domain.Entities.NodeEntity;
using Infrastructure.Repository.NodeBuilder;
using SimpleInjector;

namespace GraphColoring.DependencyResolver
{
    public static class EntityModulePackage
    {
        public static void Bootstrap(Container container)
        {
           container.Register<INodeAndArcRepository, NodeAndArcRepository>();
            container.Register<IGraphColoringSolution, GraphColoringSolution>();
        }
    }
}