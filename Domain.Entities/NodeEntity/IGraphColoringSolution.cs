namespace Domain.Entities.NodeEntity
{
    public interface IGraphColoringSolution
    {
        void AddSolution(Node node, int color);

        void RevertSolution(Node node);

        int GetSolution(Node node);

        int NumberOfNodesColored();

        int GetColorsUsed();
    }
}