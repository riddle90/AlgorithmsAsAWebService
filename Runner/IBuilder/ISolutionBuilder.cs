using System.Threading.Tasks;

namespace Runner.IBuilder
{
    public interface ISolutionBuilder
    {
        Task WriteSolution();
    }
}