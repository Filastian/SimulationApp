using SimulationApp.Core.Models;
using SimulationApp.Core.Models.Enums;
using System;

namespace SimulationApp.Core.Rules
{
    public class GameOfLifeRule : BaseSimulationRule
    {
        private int CountNeighbours(int x, int y)
        {
            int count = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int col = (x + i + GameSettings.CELL_COUNT_X) % GameSettings.CELL_COUNT_X;
                    int row = (y + j + GameSettings.CELL_COUNT_Y) % GameSettings.CELL_COUNT_Y;

                    var isSelfChecking = col == x && row == y;
                    var hasLife = _cellStates[col, row] == CellState.Entity;

                    if (hasLife && !isSelfChecking)
                        count++;
                }
            }

            return count;
        }

        public override CellState[,] GenerateNewField()
        {
            Random rand = new Random();
            _cellStates = new CellState[GameSettings.CELL_COUNT_X, GameSettings.CELL_COUNT_Y];

            for (int x = 0; x < GameSettings.CELL_COUNT_X; x++)
            {
                for (int y = 0; y < GameSettings.CELL_COUNT_Y; y++)
                {
                    _cellStates[x, y] = (int)rand.Next(4) == 0 ?
                        CellState.Entity :
                        CellState.Default;
                }
            }

            return _cellStates;
        }

        public override CellState[,] GenerateNextGeneration()
        {
            var _newArray = new CellState[GameSettings.CELL_COUNT_X, GameSettings.CELL_COUNT_Y];

            for (int x = 0; x < GameSettings.CELL_COUNT_X; x++)
            {
                for (int y = 0; y < GameSettings.CELL_COUNT_Y; y++)
                {
                    var neighbourCount = CountNeighbours(x, y);
                    var hasLife = _cellStates[x, y] == CellState.Entity;

                    if (!hasLife && neighbourCount == 3)
                    {
                        _newArray[x, y] = CellState.Entity;
                    }
                    else if (hasLife && (neighbourCount < 2 || neighbourCount > 3))
                    {
                        _newArray[x, y] = CellState.Default;
                    }
                    else
                    {
                        _newArray[x, y] = _cellStates[x, y];
                    }
                }
            }

            _cellStates = _newArray;

            return _cellStates;
        }
    }
}
