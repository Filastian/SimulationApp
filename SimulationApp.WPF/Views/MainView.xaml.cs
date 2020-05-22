using MvvmCross.Platforms.Wpf.Views;
using SimulationApp.Core.ViewModels;

namespace SimulationApp.WPF.Views
{
    public partial class MainView : MvxWpfView<MainViewModel>
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}