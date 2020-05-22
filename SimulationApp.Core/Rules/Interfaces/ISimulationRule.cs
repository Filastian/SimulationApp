using SimulationApp.Core.Models.Enums;

namespace SimulationApp.Core.Rules
{
    public interface ISimulationRule
    {
        CellState[,] GenerateNewField();
        CellState[,] GenerateNextGeneration();
    }
}