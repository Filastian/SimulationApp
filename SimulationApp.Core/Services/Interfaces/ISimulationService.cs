using SimulationApp.Core.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SimulationApp.Core.Services
{
    public interface ISimulationService : INotifyPropertyChanged
    {
        ObservableCollection<Cell> Cells { get; }

        void CreateNewField();
        void Start();
        void Pause();
    }
}