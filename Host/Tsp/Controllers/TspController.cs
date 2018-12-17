using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Runner.Mode;

namespace Tsp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TspController
    {
        private readonly IRunner _runner;

        public TspController(IRunner runner)
        {
            _runner = runner;
        }

        public async Task<string> Optimize()
        { 
            await _runner.RunOptimization();
            return "Optimization Finished";
        }
    }
}