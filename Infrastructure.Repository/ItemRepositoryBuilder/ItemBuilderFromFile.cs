using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ItemEntity;
using Infrastructure.Repository.DtoStore;
using Runner.IBuilder;
using Utility;

namespace Infrastructure.Repository.ItemRepositoryBuilder
{
    public class ItemBuilderFromFile : IItemBuilder
    {
        private readonly IItemRepository _itemRepository;
        private readonly IDtoStore _dtoStore;

        public ItemBuilderFromFile(IItemRepository itemRepository, IDtoStore dtoStore)
        {
            _itemRepository = itemRepository;
            _dtoStore = dtoStore;
        }

        public async Task Build()
        {
            var data = await _dtoStore.GetAllData();
            var dataSplitByLine = data.Split('\n');

            bool valuesParsed = ParseValues.ParseFromStringToInt(dataSplitByLine[0].Split()[0], out int count);

            if (!valuesParsed)
            {
                throw new Exception("Count Values is wrong");
            }
            for (int i = 1; i <= count; i++)
            {
                var properties = dataSplitByLine[i].Split();

                valuesParsed = ParseValues.ParseFromStringToInt(properties[0], out int value); 
                valuesParsed = ParseValues.ParseFromStringToInt(properties[1], out int weight) && valuesParsed;

                if (valuesParsed)
                {
                    var item = new Domain.Entities.ItemEntity.Item(value, weight);
                    _itemRepository.AddItem(item);
                }
            }
        }
        
    }
}