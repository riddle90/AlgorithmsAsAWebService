using System.Text;
using System.Threading.Tasks;
using Domain.Entities.RouteEntity;
using Infrastructure.Repository.DtoStore;
using Runner.IBuilder;

namespace Infrastructure.Repository.SolutionBuilder
{
    public class TspSolutionWriter : ISolutionBuilder
    {
        private readonly IDtoStore _dtoStore;
        private readonly IRouteRepository _routeRepository;

        public TspSolutionWriter(IDtoStore dtoStore, IRouteRepository routeRepository)
        {
            _dtoStore = dtoStore;
            _routeRepository = routeRepository;
        }
        
        public async Task WriteSolution()
        {
            var sb = new StringBuilder();
            foreach (var route in _routeRepository.GetAllRoutes())
            {
                sb.AppendLine($"{route.Cost} 0");

                foreach (var node in route.Nodes)
                {
                    sb.Append($"{node.Id} ");
                }
            }

            await _dtoStore.WriteSolution(sb.ToString());
        }
    }
}