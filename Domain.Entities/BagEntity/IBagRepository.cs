namespace Domain.Entities.BagEntity
{
    public interface IBagRepository
    {
        void AddBag(Bag bag);

        Bag GetBag();
    }
}