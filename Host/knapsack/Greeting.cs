using Microsoft.Extensions.Configuration;

namespace knapsack
{
    public class Greeting : IGreeting
    {
        private readonly IConfiguration _configuration;

        public Greeting(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetGreeting()
        {
            return _configuration["Greeting"];
        }
    }
}