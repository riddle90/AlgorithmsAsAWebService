using Domain.Entities.BagEntity;
using Domain.Entities.ItemEntity;
using Runner.Algorithms;

namespace Algorithms
{
    public class GreedyAlgorithm : IOptimizationAlgorithm
    {
        private readonly IItemRepository _itemRepository;
        private readonly IBagRepository _bagRepository;

        public GreedyAlgorithm(IItemRepository itemRepository, IBagRepository bagRepository)
        {
            _itemRepository = itemRepository;
            _bagRepository = bagRepository;
        }
        
        public void Optimize()
        {
            throw new System.NotImplementedException();
        }
    }
}