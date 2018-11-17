using System.Collections.Generic;
using Domain.Entities.ItemEntity;

namespace Domain.Entities.BagEntity
{
    public class Bag
    {
        public Bag(int size)
        {
            Size = size;
            RemainingCapacity = this.Size;
            _chosenItems = new List<Item>();
            _solution = new List<int>();
            ValueInsideBag = 0;
        }

        public int Size { get; }
        
        public int RemainingCapacity { get; private set; }
        
        public int ValueInsideBag { get; private set; }

        private List<Item> _chosenItems;

        private List<int> _solution;

        public void UpdateSolution(Item item)
        {
            _chosenItems.Add(item);
            this.RemainingCapacity -= item.Weight;
            ValueInsideBag += item.Value;
        }

        public List<int> GetSolution()
        {
            return _solution;
        }
        
    }
}