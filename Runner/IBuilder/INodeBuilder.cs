using System.Threading.Tasks;

namespace Runner.IBuilder
{
    public interface INodeBuilder
    {
        Task Build();
    }
}