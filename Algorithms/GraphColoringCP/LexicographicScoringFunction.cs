using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.NodeEntity;

namespace Algorithms.GraphColoringCP
{
    public class LexicographicScoringFunction : IScoringFunction
    {
        public SortedDictionary<string, List<Node>> ScoringDictionary { get; private set; }

        public Dictionary<Node, string> NodeScore { get; private set; }

        public LexicographicScoringFunction(IEnumerable<Node> allNodes, int maxColorsAllowed)
        {
            ScoringDictionary = new SortedDictionary<string, List<Node>>();
            NodeScore = new Dictionary<Node, string>();
            foreach (var node in allNodes)
            {
                string numCandidates = Convert.ToString(maxColorsAllowed, 2);
                string impactedNodes = Convert.ToString(node.AdjacencyList.Count(), 2);
                string score = numCandidates + impactedNodes;

                if (!ScoringDictionary.ContainsKey(score))
                {
                    ScoringDictionary.Add(score, new List<Node>());
                }

                ScoringDictionary[score].Add(node);
                NodeScore.Add(node, score);
            }
        }

        public LexicographicScoringFunction(LexicographicScoringFunction scoringFunction)
        {
            this.ScoringDictionary = new SortedDictionary<string, List<Node>>();
            this.NodeScore = new Dictionary<Node, string>();
            foreach (var score in scoringFunction.ScoringDictionary.Keys)
            {
                this.ScoringDictionary.Add(score, new List<Node>(scoringFunction.ScoringDictionary[score]));
            }

            foreach (KeyValuePair<Node,string> keyValuePair in scoringFunction.NodeScore)
            {
                this.NodeScore.Add(keyValuePair.Key, keyValuePair.Value);
            }
        }

        public void UpdateScore(Node selectedNode, DomainStore domainStore)
        {
            foreach (var node in selectedNode.AdjacencyList)
            {
                if(node.IsColorAssigned)
                    continue;
                
                var numCandidates = Convert.ToString(domainStore.MaxColorsAllowed - domainStore.Domain[node].Count, 2);
                var impactedNodes = Convert.ToString(node.AdjacencyList.Count, 2);
                var newScore = numCandidates + impactedNodes;

                var oldScore = this.NodeScore[node];
                this.ScoringDictionary[oldScore].Remove(node);

                if (this.ScoringDictionary[oldScore].Count == 0)
                {
                    this.ScoringDictionary.Remove(oldScore);
                }

                this.NodeScore[node] = newScore;

                if (!this.ScoringDictionary.ContainsKey(newScore))
                {
                    this.ScoringDictionary.Add(newScore, new List<Node>());
                }
                
                this.ScoringDictionary[newScore].Add(node);
            }
        }

        public Node GetNewNode()
        {
            var bestScore = this.ScoringDictionary.Keys.Reverse().FirstOrDefault();
            if (bestScore == null)
                return null;

            var node =  this.ScoringDictionary[bestScore].FirstOrDefault();

            if (node != null)
            {
                this.ScoringDictionary[bestScore].Remove(node);

                if (ScoringDictionary[bestScore].Count == 0)
                {
                    ScoringDictionary.Remove(bestScore);
                }
            }

            return node;
        }
    }
}