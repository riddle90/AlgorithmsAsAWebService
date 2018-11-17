using Infrastructure.Repository.DtoStore;
using SimpleInjector;

namespace knapsack.DependencyResolver
{
    public static class InfrastructureModulePackage
    {
        public static void Bootstrap(Container container)
        {
            container.Register<IDtoStore, DtoStore>();
        }
    }
}