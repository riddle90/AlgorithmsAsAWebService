using System.Collections.ObjectModel;
using Domain.Entities.NodeEntity;

namespace Algorithms.GraphColoringCP
{
    public interface ISearchAlgorithm
    {
        bool SearchFurther(Node node, int chosenColor, DomainStore domainStore,
            LexicographicScoringFunction scoringFunction, GraphColoringSolution solution);
    }
}