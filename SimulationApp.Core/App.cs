using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using SimulationApp.Core.Rules;
using SimulationApp.Core.Services;
using SimulationApp.Core.ViewModels;

namespace SimulationApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ISimulationRule, GameOfLifeRule>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ISimulationService, BaseSimulationService>();

            RegisterAppStart<MainViewModel>();
        }
    }
}