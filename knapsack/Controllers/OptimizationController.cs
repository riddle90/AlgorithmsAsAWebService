using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Runner;

namespace knapsack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptimizationController
    {
        private readonly IRunner _runner;

        public OptimizationController(IRunner runner)
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