using System.Runtime.CompilerServices;
using Domain.Entities.BagEntity;
using Domain.Entities.ItemEntity;
using Runner.Algorithms;

namespace Algorithms.DynamicProgramming
{
    public class DynamicProgrammingAlgorithm : IOptimizationAlgorithm
    {
        private readonly IBagRepository _bagRepository;
        private readonly IItemRepository _itemRepository;

        public DynamicProgrammingAlgorithm(IBagRepository bagRepository, IItemRepository itemRepository)
        {
            _bagRepository = bagRepository;
            _itemRepository = itemRepository;
        }
        public void Optimize()
        {
            var bag = _bagRepository.GetBag();
            var items = _itemRepository.GetAllItems();
            
            var solutionMatrix = new SolutionMatrix(bag.RemainingCapacity, items.Count);

            for (int col = 0; col < items.Count; col++)
            {
                for (int row = 0; row < bag.RemainingCapacity; row++)
                {
                    int capacity = row;
                    int itemSize = items[col].Weight;
                    
                }
            }
            
        }
    }
}