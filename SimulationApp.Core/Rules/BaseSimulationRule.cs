using SimulationApp.Core.Models.Enums;

namespace SimulationApp.Core.Rules
{
    public class BaseSimulationRule : ISimulationRule
    {
        protected CellState[,] _cellStates;

        public virtual CellState[,] GenerateNewField()
        {
            return default;
        }

        public virtual CellState[,] GenerateNextGeneration()
        {
            return default;
        }
    }
}
