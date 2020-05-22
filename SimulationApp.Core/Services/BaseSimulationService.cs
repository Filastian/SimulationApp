using SimulationApp.Core.Models;
using SimulationApp.Core.Models.Enums;
using SimulationApp.Core.Rules;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace SimulationApp.Core.Services
{
    public class BaseSimulationService : ISimulationService
    {
        protected readonly ISimulationRule _simulationRule;

        protected GameState State = GameState.IsStop;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Cell> Cells { get; private set; }

        public BaseSimulationService(ISimulationRule simulationRule)
        {
            _simulationRule = simulationRule;

            Init();
            StartTimer();
        }

        private void Init()
        {
            Cells = new ObservableCollection<Cell>();

            for (int x = 0; x < GameSettings.CELL_COUNT_X; x++)
            {
                for (int y = 0; y < GameSettings.CELL_COUNT_Y; y++)
                {
                    Cells.Add(new Cell
                    {
                        State = CellState.Default,
                        X = x * GameSettings.CELL_SIZE,
                        Y = y * GameSettings.CELL_SIZE,
                        Width = GameSettings.CELL_SIZE,
                        Height = GameSettings.CELL_SIZE
                    });
                }
            }
        }

        private void StartTimer()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(100);

                    if (State == GameState.IsPlay)
                        await UpdateField();
                }
            });
        }

        protected virtual Task UpdateField()
        {
            var statesArray = _simulationRule.GenerateNextGeneration();
            UpdateCellsCollection(statesArray);

            return Task.CompletedTask;
        }

        protected virtual void UpdateCellsCollection(CellState[,] cellStates)
        {
            for (int x = 0; x < GameSettings.CELL_COUNT_X; x++)
            {
                for (int y = 0; y < GameSettings.CELL_COUNT_Y; y++)
                {
                    var index = GameSettings.CELL_COUNT_X * x + y;

                    Cells[index].State = cellStates[x, y];
                }
            }
        }

        public virtual void CreateNewField()
        {
            var statesArray = _simulationRule.GenerateNewField();
            UpdateCellsCollection(statesArray);
        }

        public virtual void Start()
        {
            State = GameState.IsPlay;
        }

        public virtual void Pause()
        {
            State = GameState.IsPause;
        }
    }
}
