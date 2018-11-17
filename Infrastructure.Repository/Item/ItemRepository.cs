using System.Collections.Generic;
using System.Linq;
using Domain.Entities.Items;

namespace Infrastructure.Repository.Item
{
    public class ItemRepository : IItemRepository
    {
        private List<Domain.Entities.Items.Item> _allItems;
        private SortedList<Domain.Entities.Items.Item, double> _allUnpickedItems;
        private List<int> _solution;
        private Dictionary<Domain.Entities.Items.Item, int> _indexOfItem;

        public ItemRepository()
        {
            _allItems = new List<Domain.Entities.Items.Item>();
            _allUnpickedItems = new SortedList<Domain.Entities.Items.Item, double>();
            _solution = new List<int>();
            _indexOfItem = new Dictionary<Domain.Entities.Items.Item, int>();
        }

        public void AddItem(Domain.Entities.Items.Item item)
        {
            _indexOfItem.Add(item, _allItems.Count);
            _allItems.Add(item);
            _allUnpickedItems.Add(item, item.Value);
            _solution.Add(0);
            

        }

        public Domain.Entities.Items.Item GetUnpickedItemWithHighestValuePerUnitWeight()
        {
            return _allUnpickedItems.First().Key;
        }

        public void RemoveFromUnpickedAfterSuccess(Domain.Entities.Items.Item item)
        {
            _allUnpickedItems.Remove(item);
            _solution[_indexOfItem[item]] = 1;
        }

        public void RemoveFromUnpickedAfterFailure(Domain.Entities.Items.Item item)
        {
            _allUnpickedItems.Remove(item);
        }

        public List<int> GetSolution()
        {
            return _solution;
        }
    }
}