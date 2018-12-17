using System.Text;
using System.Threading.Tasks;
using Domain.Entities.BagEntity;
using Domain.Entities.ItemEntity;
using Infrastructure.Repository.DtoStore;
using Runner.IBuilder;

namespace Infrastructure.Repository.SolutionBuilder
{
    public class KnapsackSolutionWriterToFile : ISolutionBuilder
    {
        private readonly IDtoStore _dtoStore;
        private readonly IItemRepository _itemRepository;
        private readonly IBagRepository _bagRepository;

        public KnapsackSolutionWriterToFile(IDtoStore dtoStore, IItemRepository itemRepository, IBagRepository bagRepository)
        {
            _dtoStore = dtoStore;
            _itemRepository = itemRepository;
            _bagRepository = bagRepository;
        }
        public async Task WriteSolution()
        {
            var bag = _bagRepository.GetBag();
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{bag.ValueInsideBag} 0");

            foreach (var isItemChosen in _itemRepository.GetSolution())
            {
                sb.Append($"{isItemChosen} ");
            }

            await _dtoStore.WriteSolution(sb.ToString());
        }
    }
}