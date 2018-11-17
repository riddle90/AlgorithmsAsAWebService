using System.Security.Cryptography.X509Certificates;
using Domain.Entities.BagEntity;
using Domain.Entities.ItemEntity;
using Infrastructure.Repository.BagBuilder;
using Infrastructure.Repository.ItemRepositoryBuilder;
using SimpleInjector;

namespace knapsack.DependencyResolver
{
    public static class EntityModulePackage
    {
        public static void Bootstrap(Container container)
        {
            container.Register<IBagRepository, BagRepository>();
            container.Register<IItemRepository, ItemRepository>();
        }
    }
}