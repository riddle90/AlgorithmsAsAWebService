using System.Threading.Tasks;
using Domain.Entities.NodeEntity;

namespace Runner.IBuilder
{
    public interface IGraphColoringSolutionBuilder
    {
        Task WriteSolution(IGraphColoringSolution solution);
    }
}