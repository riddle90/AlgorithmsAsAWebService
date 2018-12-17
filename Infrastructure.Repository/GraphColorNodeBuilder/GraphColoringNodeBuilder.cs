using System;
using System.Threading.Tasks;
using Domain.Entities.BagEntity;
using Domain.Entities.NodeEntity;
using Infrastructure.Repository.DtoStore;
using Runner.IBuilder;
using Utility;

namespace Infrastructure.Repository.NodeBuilder
{
    public class GraphColoringNodeBuilder : INodeBuilder
    {
        private readonly IDtoStore _dtoStore;
        private readonly INodeAndArcRepository _nodeAndArcRepository;

        public GraphColoringNodeBuilder(IDtoStore dtoStore, INodeAndArcRepository nodeAndArcRepository)
        {
            _dtoStore = dtoStore;
            _nodeAndArcRepository = nodeAndArcRepository;
        }
        
        public async Task Build()
        {
            var data = await _dtoStore.GetAllData();

            var lines = data.Split('\n');
            var properties = lines[0].Split();
            
            var parseSuccessful = ParseValues.ParseFromStringToInt(properties[0], out int numNodes);
            CreateNodes(parseSuccessful, numNodes);

            parseSuccessful = ParseValues.ParseFromStringToInt(properties[1], out int numEdges);
            CreateArcs(parseSuccessful, numEdges, lines);

        }

        private void CreateArcs(bool parseSuccessful, int numEdges, string[] lines)
        {
            if (parseSuccessful)
            {
                for (int i = 1; i <= numEdges; i++)
                {
                    var properties = lines[i].Split();

                    parseSuccessful = ParseValues.ParseFromStringToInt(properties[0], out int sourceNodeId);
                    parseSuccessful = ParseValues.ParseFromStringToInt(properties[1], out int destinationId) &&
                                      parseSuccessful;

                    if (!parseSuccessful)
                    {
                        continue;
                    }
                    
                    _nodeAndArcRepository.AddArc(sourceNodeId, destinationId);
                }
            }
            else
            {
                throw new Exception("Num of edges data was not parsed successfully");
            }
        }

        private void CreateNodes(bool parseSuccessful, int numNodes)
        {
            if (parseSuccessful)
            {
                for (int i = 0; i < numNodes; i++)
                {
                    var node = new Node(i);
                    _nodeAndArcRepository.AddNode(node);
                }
            }
            else
            {
                throw new Exception("Number of Nodes data is incorrect");
            }
        }
    }
}