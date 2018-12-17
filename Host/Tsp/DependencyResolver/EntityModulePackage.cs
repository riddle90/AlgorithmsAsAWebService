using Algorithms.GraphColoringCP;
using Domain.Entities.NodeEntity;
using Domain.Entities.RouteEntity;
using Infrastructure.Repository;
using Infrastructure.Repository.RouteBuilder;
using SimpleInjector;

namespace Tsp.DependencyResolver
{
    public static class EntityModulePackage
    {
        public static void Bootstrap(Container container)
        {
           container.Register<INodeAndArcRepository, NodeAndArcRepository>();
            container.Register<IRouteRepository, RouteRepository>();
        }
    }
}