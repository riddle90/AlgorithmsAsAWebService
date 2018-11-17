using Infrastructure.Repository.BagBuilder;
using Infrastructure.Repository.ItemRepositoryBuilder;
using Infrastructure.Repository.SolutionBuilder;
using Runner.IBuilder;
using SimpleInjector;

namespace knapsack.DependencyResolver
{
    public static class EntityBuilderFactory
    {
        public static void Bootstrap(Container container)
        {
            container.Register<IBagBuilder, BagBuilderFromFile>();
            container.Register<IItemBuilder, ItemBuilderFromFile>();
            container.Register<ISolutionBuilder, SolutionWriterToFile>();
        }
    }
}