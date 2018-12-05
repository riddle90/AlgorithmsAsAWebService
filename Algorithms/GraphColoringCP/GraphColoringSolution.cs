using System.Collections.Generic;
using System.Linq;
using Domain.Entities.NodeEntity;

namespace Algorithms.GraphColoringCP
{
    public class GraphColoringSolution : IGraphColoringSolution
    {
        public Dictionary<Node, int> SelectedNodeColor { get; private set; }

        public GraphColoringSolution()
        {
            SelectedNodeColor = new Dictionary<Node, int>();
        }

        public void AddSolution(Node node, int color)
        {
            SelectedNodeColor.Add(node, color);
            node.IsColorAssigned = true;
        }

        public void RevertSolution(Node node)
        {
            SelectedNodeColor.Remove(node);
            node.IsColorAssigned = false;
        }

        public int GetSolution(Node node)
        {
            return SelectedNodeColor[node];
        }

        public int NumberOfNodesColored()
        {
            return this.SelectedNodeColor.Count;
        }

        public int GetColorsUsed()
        {
            int highestColorId = SelectedNodeColor.Values.OrderByDescending(x => x).First();

            return highestColorId + 1;
        }
    }
}