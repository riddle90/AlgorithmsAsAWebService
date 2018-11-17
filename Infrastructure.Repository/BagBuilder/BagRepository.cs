using Domain.Entities.BagEntity;

namespace Infrastructure.Repository.BagBuilder
{
    public class BagRepository : IBagRepository
    {
        private Bag _bag;

        public void AddBag(Bag bag)
        {
            this._bag = bag;
        }

        public Bag GetBag()
        {
            return _bag;
        }
    }
}