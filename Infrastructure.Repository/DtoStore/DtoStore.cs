using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repository.DtoStore
{
    public class DtoStore : IDtoStore
    {
        private readonly IConfiguration _configuration;

        public DtoStore(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public async Task<string> GetBagData()
        {
            using (StreamReader streamReader = new StreamReader(_configuration["InputFileName"]))
            {
                string data = await streamReader.ReadLineAsync();
                return data;
            }
        }

        public async Task<string> GetItemData()
        {
            using (StreamReader streamReader = new StreamReader(_configuration["InputFileName"]))
            {
                string data = await streamReader.ReadToEndAsync();
                return data;
            }
        }
    }
}