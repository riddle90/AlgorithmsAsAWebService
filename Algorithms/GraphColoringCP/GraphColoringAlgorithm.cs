using System.Linq;
using Domain.Entities.NodeEntity;
using Runner.Algorithms;

namespace Algorithms.GraphColoringCP
{
    public class GraphColoringAlgorithm : IGraphColoringAlgorithm
    {
        private readonly INodeAndArcRepository _nodeAndArcRepository;
        private readonly ISearchAlgorithm _searchAlgorithm;

        public GraphColoringAlgorithm(INodeAndArcRepository nodeAndArcRepository, ISearchAlgorithm searchAlgorithm)
        {
            _nodeAndArcRepository = nodeAndArcRepository;
            _searchAlgorithm = searchAlgorithm;
        }
        
        public IGraphColoringSolution Optimize()
        {
            GraphColoringSolution bestSolution = null;
            var solutionInfeasible = false;
            var maxColorsAllowed = _nodeAndArcRepository.GetAllNodes().Count();

            while (!solutionInfeasible)
            {
                var domainStore = new DomainStore(_nodeAndArcRepository.GetAllNodes(), maxColorsAllowed);
                var scoringFunction = new LexicographicScoringFunction(_nodeAndArcRepository.GetAllNodes(), maxColorsAllowed);
                var solution = new GraphColoringSolution();
                
                var firstNode = scoringFunction.GetNewNode();
                solutionInfeasible =  _searchAlgorithm.SearchFurther(firstNode, 0, domainStore, scoringFunction, solution);

                if (!solutionInfeasible)
                {
                    bestSolution = solution;
                    maxColorsAllowed = solution.GetColorsUsed();
                }

                //solutionInfeasible = true;

            }
            return bestSolution;
        }
    }
}