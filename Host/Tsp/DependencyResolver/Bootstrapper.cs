using SimpleInjector;

namespace Tsp.DependencyResolver
{
    public class Bootstrapper
    {

        public static void InitializeContainer(Container container)
        {
            InfrastructureModulePackage.Bootstrap(container);
            EngineModulePackage.Bootstrap(container);
            EntityBuilderFactory.Bootstrap(container);
            EntityModulePackage.Bootstrap(container);
            
            container.Verify();
        }
        
    }
}