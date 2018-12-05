using System.Linq;
using Domain.Entities.NodeEntity;

namespace Algorithms.GraphColoringCP
{
    public class SearchAlgorithm : ISearchAlgorithm
    {
        public bool SearchFurther(Node prevnode, int chosenColor, DomainStore domainStore,
            LexicographicScoringFunction scoringFunction, GraphColoringSolution solution)
        {
            if (domainStore.UpdateDomainStore(prevnode, chosenColor))
            {
                return true;
            }

            scoringFunction.UpdateScore(prevnode, domainStore);
            solution.AddSolution(prevnode, chosenColor);

            var nextNode = scoringFunction.GetNewNode();

            if (solution.NumberOfNodesColored() == domainStore.Domain.Count())
            {
                return false;
            }

            foreach (var colorOption in domainStore.GetPossibleOptions(nextNode).ToList())
            {
                var solutionRejected = SearchFurther(nextNode, colorOption, new DomainStore(domainStore),
                    new LexicographicScoringFunction(scoringFunction), solution);

                if (solutionRejected)
                {
                    solution.RevertSolution(nextNode);
//                    if (domainStore.UpdateDomainStoreAfterBacktrack(nextNode, colorOption))
//                    {
//                        return true;
//                    }
                }
                else
                {
                    return false;
                }

            }

            return true;
        }
    }
}