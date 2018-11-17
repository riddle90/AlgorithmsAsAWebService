using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Items;
using Infrastructure.Repository.DtoStore;

namespace Infrastructure.Repository.Item
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
            var data = await _dtoStore.GetItemData();
            var dataSplitByLine = data.Split('\n');

            for (int i = 1; i < dataSplitByLine.Count(); i++)
            {
                var item = dataSplitByLine[i].Split();
            }
        }
    }
}