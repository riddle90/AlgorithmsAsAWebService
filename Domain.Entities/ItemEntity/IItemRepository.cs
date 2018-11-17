using System.Collections.Generic;

namespace Domain.Entities.ItemEntity
{
    public interface IItemRepository
    {
        void AddItem(Item item);

        List<Item> GetAllItems();

        void UpdateSolution(Item item);

        List<int> GetSolution();
    }
}