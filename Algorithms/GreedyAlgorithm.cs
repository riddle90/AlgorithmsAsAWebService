using System.Linq;
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
            if (!AlgorithmPicker.ShouldRunOnThisDataSet(this, _itemRepository.GetItemCount()))
            {
                return;
            }
            
            Bag bag = _bagRepository.GetBag();
            var items = _itemRepository.GetAllItems().OrderByDescending(x => x.ValuePerUnitWeight);

            foreach (var item in items)
            {
                if (item.Weight <= bag.RemainingCapacity)
                {
                    bag.UpdateSolution(item);
                    _itemRepository.UpdateSolution(item);
                }

                if (bag.RemainingCapacity == 0)
                {
                    break;
                }

            }
        }
    }
}