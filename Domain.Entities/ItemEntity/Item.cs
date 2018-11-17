using System;

namespace Domain.Entities.ItemEntity
{
    public class Item : IEquatable<Item>, IComparable<Item>
    {
        public Item(int value, int weight)
        {
            Id = Guid.NewGuid();
            Weight = weight;
            Value = value;
            ValuePerUnitWeight =  (double) value / weight;
        }
        
        private Guid Id { get; }

        public int Weight { get; }
        
        public int Value { get; }
        
        public double ValuePerUnitWeight { get; }

        public bool Equals(Item other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Item) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public int CompareTo(Item other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
           
            return ValuePerUnitWeight.CompareTo(other.ValuePerUnitWeight);
        }
    }
}