namespace Domain.Entities.ItemEntity
{
    public class Item
    {
        public Item(int value, int weight)
        {
            Weight = weight;
            Value = value;
            ValuePerUnitWeight =  (double) value / weight;
        }

        public int Weight { get; }
        
        public int Value { get; }
        
        public double ValuePerUnitWeight { get; }
    }
}