using System.Collections.Generic;
using System.Linq;
using Domain.Entities.ItemEntity;

namespace Infrastructure.Repository.Item
{
    public class ItemRepository : IItemRepository
    {
        private List<Domain.Entities.ItemEntity.Item> _allItems;
        private SortedList<Domain.Entities.ItemEntity.Item, double> _allUnpickedItems;
        private List<int> _solution;
        private Dictionary<Domain.Entities.ItemEntity.Item, int> _indexOfItem;

        public ItemRepository()
        {
            _allItems = new List<Domain.Entities.ItemEntity.Item>();
            _allUnpickedItems = new SortedList<Domain.Entities.ItemEntity.Item, double>();
            _solution = new List<int>();
            _indexOfItem = new Dictionary<Domain.Entities.ItemEntity.Item, int>();
        }

        public void AddItem(Domain.Entities.ItemEntity.Item item)
        {
            _indexOfItem.Add(item, _allItems.Count);
            _allItems.Add(item);
            _allUnpickedItems.Add(item, item.Value);
            _solution.Add(0);
            

        }

        public Domain.Entities.ItemEntity.Item GetUnpickedItemWithHighestValuePerUnitWeight()
        {
            return _allUnpickedItems.First().Key;
        }

        public void RemoveFromUnpickedAfterSuccess(Domain.Entities.ItemEntity.Item item)
        {
            _allUnpickedItems.Remove(item);
            _solution[_indexOfItem[item]] = 1;
        }

        public void RemoveFromUnpickedAfterFailure(Domain.Entities.ItemEntity.Item item)
        {
            _allUnpickedItems.Remove(item);
        }

        public List<int> GetSolution()
        {
            return _solution;
        }
    }
}