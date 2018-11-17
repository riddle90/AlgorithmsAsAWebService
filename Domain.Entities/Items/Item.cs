namespace Domain.Entities.Items
{
    public class Item
    {
        public Item(int weight, int value)
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