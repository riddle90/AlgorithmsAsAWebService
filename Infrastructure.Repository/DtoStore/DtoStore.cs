using System.IO;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.BagEntity;
using Domain.Entities.ItemEntity;
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

        public async Task WriteSolution(string finalOutput)
        {
            using (StreamWriter streamWriter = new StreamWriter(_configuration["OutputFileName"]))
            {
                await streamWriter.WriteAsync(finalOutput);
            }
        }
    }
}