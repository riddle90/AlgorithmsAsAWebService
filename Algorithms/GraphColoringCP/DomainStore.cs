using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Domain.Entities.NodeEntity;

namespace Algorithms.GraphColoringCP
{
    public class DomainStore
    {
        public Dictionary<Node, HashSet<int>> Domain { get; private set; }

        public int MaxColorsAllowed { get; private set; }

        public DomainStore(IEnumerable<Node> allNodes, int maxColorsAllowed)
        {
            Domain = new Dictionary<Node, HashSet<int>>();
            
            foreach (var node in allNodes)
            {
                Domain.Add(node, Enumerable.Range(0, maxColorsAllowed - 1).ToHashSet());
                node.IsColorAssigned = false;
            }

            this.MaxColorsAllowed = maxColorsAllowed;
        }

        public DomainStore(DomainStore oldDomain)
        {
            Domain = new Dictionary<Node, HashSet<int>>(oldDomain.Domain);
            this.MaxColorsAllowed = oldDomain.MaxColorsAllowed;
        }

        public IEnumerable<int> GetPossibleOptions(Node node)
        {
            return Domain[node];
        }

        public bool UpdateDomainStore(Node node, int assignedColor)
        {
            bool isSolutionInfeasible = false;
            foreach (var neighborNode in node.AdjacencyList)
            {
                if (Domain[neighborNode].Contains(assignedColor))
                {
                    Domain[neighborNode].Remove(assignedColor);

                    if (!neighborNode.IsColorAssigned && Domain[neighborNode].Count == 0)
                    {
                        isSolutionInfeasible = true;
                    }
                }
            }

            return isSolutionInfeasible;
        }

        public bool UpdateDomainStoreAfterBacktrack(Node node, int rejectedColor)
        {
            var isSolutionInFeasible = false;
            Domain[node].Remove(rejectedColor);

            if (Domain[node].Count==0)
            {
                isSolutionInFeasible = true;
            }

            return isSolutionInFeasible;
        }
      
    }
}