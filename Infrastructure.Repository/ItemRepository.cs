using System.Collections.Generic;
using System.Linq;
using Domain.Entities.Items;

namespace Infrastructure.Repository
{
    public class ItemRepository : IItemRepository
    {
        private List<Item> _allItems;
        private SortedList<Item, double> _allUnpickedItems;
        private List<int> _solution;
        private Dictionary<Item, int> _indexOfItem;

        public ItemRepository()
        {
            _allItems = new List<Item>();
            _allUnpickedItems = new SortedList<Item, double>();
            _solution = new List<int>();
            _indexOfItem = new Dictionary<Item, int>();
        }

        public void AddItem(Item item)
        {
            _indexOfItem.Add(item, _allItems.Count);
            _allItems.Add(item);
            _allUnpickedItems.Add(item, item.Value);
            _solution.Add(0);
            

        }

        public Item GetUnpickedItemWithHighestValuePerUnitWeight()
        {
            return _allUnpickedItems.First().Key;
        }

        public void RemoveFromUnpickedAfterSuccess(Item item)
        {
            _allUnpickedItems.Remove(item);
            _solution[_indexOfItem[item]] = 1;
        }

        public void RemoveFromUnpickedAfterFailure(Item item)
        {
            _allUnpickedItems.Remove(item);
        }

        public List<int> GetSolution()
        {
            return _solution;
        }
    }
}