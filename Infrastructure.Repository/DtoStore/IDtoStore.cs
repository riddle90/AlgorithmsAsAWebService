using System.Threading.Tasks;

namespace Infrastructure.Repository.DtoStore
{
    public interface IDtoStore
    {
        Task<string> GetFirstLine();

        Task<string> GetAllData();

        Task WriteSolution(string finalOutput);
    }
}