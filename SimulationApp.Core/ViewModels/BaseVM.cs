using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimulationApp.Core.ViewModels
{
    public class BaseVM : MvxViewModel
    {
        protected IMvxNavigationService NavigationService { get; }

        public ICommand CloseCommand { get; private set; }

        public BaseVM(IMvxNavigationService navigationService)
        {
            NavigationService = navigationService;

            CloseCommand = new MvxAsyncCommand(CloseAsync);
        }

        protected Task CloseAsync()
        {
            return NavigationService.Close(this, CancellationToken.None);
        }
    }
}
