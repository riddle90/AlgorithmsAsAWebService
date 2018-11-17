using System.Collections.Generic;

namespace Domain.Entities.Items
{
    public interface IItemRepository
    {
        void AddItem(Item item);

        Item GetUnpickedItemWithHighestValuePerUnitWeight();

        void RemoveFromUnpickedAfterSuccess(Item item);

        void RemoveFromUnpickedAfterFailure(Item item);

        List<int> GetSolution();
    }
}