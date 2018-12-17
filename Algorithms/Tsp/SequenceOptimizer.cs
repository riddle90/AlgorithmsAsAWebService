using System.Diagnostics;
using Runner.Algorithms;
using Runner.Mode;

namespace Algorithms.Tsp
{
    public class SequenceOptimizer : ISequenceOptimizer
    {
        private readonly ITwoOpt _twoOpt;
        private readonly IOrOpt _orOpt;
        private readonly IConstructionAlgorithm _constructionAlgorithm;
        private readonly ICostCalculator _costCalculator;

        public SequenceOptimizer(ITwoOpt twoOpt, IOrOpt orOpt, IConstructionAlgorithm constructionAlgorithm)
        {
            _twoOpt = twoOpt;
            _orOpt = orOpt;
            _constructionAlgorithm = constructionAlgorithm;
        }
        
        public void RunOptimization()
        {
            this.RunConstruction();
            this.RunImprovement();
        }

        private void RunImprovement()
        {
            var sw = new Stopwatch();
            sw.Start();
            bool improvementFound = true;

            while (improvementFound)
            {
                improvementFound = _orOpt.Optimize();
                improvementFound = _twoOpt.Optimize() || improvementFound;
                if (sw.Elapsed.TotalMinutes > 30)
                {
                    improvementFound = false;
                }

            }
        }

        private void RunConstruction()
        {
            _constructionAlgorithm.CreateRoute();

        }
    }
}