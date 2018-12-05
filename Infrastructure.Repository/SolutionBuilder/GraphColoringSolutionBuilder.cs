using System.Text;
using System.Threading.Tasks;
using Domain.Entities.NodeEntity;
using Infrastructure.Repository.DtoStore;
using Runner.IBuilder;

namespace Infrastructure.Repository.SolutionBuilder
{
    public class GraphColoringSolutionBuilder : IGraphColoringSolutionBuilder
    {
        private readonly INodeAndArcRepository _nodeAndArcRepository;
        private readonly IDtoStore _dtoStore;

        public GraphColoringSolutionBuilder(INodeAndArcRepository nodeAndArcRepository, IDtoStore dtoStore)
        {
            _nodeAndArcRepository = nodeAndArcRepository;
            _dtoStore = dtoStore;
        }
        
        public async Task WriteSolution(IGraphColoringSolution solution)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{solution.GetColorsUsed()} 0");

            foreach (var node in _nodeAndArcRepository.GetAllNodes())
            {
                sb.Append($"{solution.GetSolution(node)} ");
            }
            
            await _dtoStore.WriteSolution(sb.ToString());
        }
    }
}