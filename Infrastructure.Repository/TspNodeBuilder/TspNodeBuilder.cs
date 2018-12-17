using System;
using System.Threading.Tasks;
using Domain.Entities.NodeEntity;
using Infrastructure.Repository.DtoStore;
using Runner.IBuilder;
using Utility;

namespace Infrastructure.Repository.TspNodeBuilder
{
    public class TspNodeBuilder : INodeBuilder
    {
        private readonly IDtoStore _dtoStore;
        private readonly INodeAndArcRepository _nodeAndArcRepository;

        public TspNodeBuilder(IDtoStore dtoStore, INodeAndArcRepository nodeAndArcRepository)
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

            if (!parseSuccessful)
            {
                throw new Exception("Bad Data");
            }

            CreateNodes(numNodes, lines);
            //CreateArcs();
        }

        private void CreateArcs()
        {
            foreach (var node1 in _nodeAndArcRepository.GetAllNodes())
            {
                foreach (var node2 in _nodeAndArcRepository.GetAllNodes())
                {
                    if (node1.Equals(node2))
                    {
                        continue;
                    }

                    _nodeAndArcRepository.AddArc(node1.Id, node2.Id);
                }
            }
        }

        private void CreateNodes(int numNodes, string[] lines)
        {
            bool parseSuccessful;
            for (int i = 0; i < numNodes; i++)
            {
                var coordinates = lines[i + 1].Split();

                parseSuccessful = ParseValues.ParseFromStringToDouble(coordinates[0], out double xCoord);
                parseSuccessful = ParseValues.ParseFromStringToDouble(coordinates[1], out double yCoord) && parseSuccessful;

                if (!parseSuccessful)
                {
                    throw new Exception("Bad Data");
                }

                Node node = new Node(i, xCoord, yCoord);

                _nodeAndArcRepository.AddNode(node);
            }
        }
    }
}