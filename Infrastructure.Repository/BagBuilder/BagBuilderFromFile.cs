using System;
using System.Threading.Tasks;
using Domain.Entities.BagEntity;
using Infrastructure.Repository.DtoStore;
using Runner.IBuilder;
using Utility;

namespace Infrastructure.Repository.BagBuilder
{
    public class BagBuilderFromFile : IBagBuilder
    {
        private readonly IBagRepository _bagRepository;
        private readonly IDtoStore _dtoStore;

        public BagBuilderFromFile(IBagRepository bagRepository, IDtoStore dtoStore)
        {
            _bagRepository = bagRepository;
            _dtoStore = dtoStore;
        }
        public async Task Build()
        {
            var data = await _dtoStore.GetFirstLine();
            var properties = data.Split();

            var parseSuccessful = ParseValues.ParseFromStringToInt(properties[1], out int capacity);

            if (parseSuccessful)
            {
                var bag = new Bag(capacity);
                _bagRepository.AddBag(bag);
            }
            else
            {
                throw new Exception("Bag Data is incorrect");
            }

        }
    }
}