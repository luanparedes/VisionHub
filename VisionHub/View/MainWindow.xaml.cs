using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml;
using VisionHub.ViewModel;

namespace VisionHub.View
{
    public sealed partial class MainWindow : Window
    {
        private MainWindowViewModel ViewModel { get; }

        public MainWindow()
        {
            this.InitializeComponent();
            ViewModel = Ioc.Default.GetService<MainWindowViewModel>();
        }
    }
}
