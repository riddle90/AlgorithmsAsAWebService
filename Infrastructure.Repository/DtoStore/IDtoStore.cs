using System.Threading.Tasks;

namespace Infrastructure.Repository.DtoStore
{
    public interface IDtoStore
    {
        Task<string> GetBagData();

        Task<string> GetItemData();
    }
}