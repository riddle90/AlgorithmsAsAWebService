using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Domain.Entities.ItemEntity;

namespace Infrastructure.Repository.ItemRepositoryBuilder
{
    public class ItemRepository : IItemRepository
    {
        private List<Item> _allItems;
        private Dictionary<Item, int> _indexOfItem;
        private List<int> _solution;

        public ItemRepository()
        {
            _allItems = new List<Domain.Entities.ItemEntity.Item>();
            _indexOfItem = new Dictionary<Domain.Entities.ItemEntity.Item, int>();
            _solution = new List<int>();
        }

        public void AddItem(Domain.Entities.ItemEntity.Item item)
        {
            _indexOfItem.Add(item, _allItems.Count);
            _allItems.Add(item);
            _solution.Add(0);
        }

        public List<Item> GetAllItems()
        {
            return _allItems;
        }

        public int GetItemCount()
        {
            return _allItems.Count;
        }

        public void UpdateSolution(Item item)
        {
            _solution[_indexOfItem[item]] = 1;
        }

        public List<int> GetSolution()
        {
            return _solution;
        }
       
    }
}