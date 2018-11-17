using System.Threading.Tasks;

namespace Infrastructure.Repository.Item
{
    public interface IItemBuilder
    {
        Task Build(); 
    }
}