using MvvmCross.Commands;
using MvvmCross.Navigation;
using SimulationApp.Core.Services;

namespace SimulationApp.Core.ViewModels
{
    public class MainViewModel : BaseVM
    {
        public ISimulationService SimulationService { get; }

        public IMvxCommand CreateNewCommand { get; }
        public IMvxCommand StartCommand { get; }
        public IMvxCommand PauseCommand { get; }

        public MainViewModel(
            IMvxNavigationService navigationService,
            ISimulationService simulationService)
            : base(navigationService)
        {
            SimulationService = simulationService;

            CreateNewCommand = new MvxCommand(() => SimulationService.CreateNewField());
            StartCommand = new MvxCommand(() => SimulationService.Start());
            PauseCommand = new MvxCommand(() => SimulationService.Pause());
        }
    }
}
