using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.Windows.AppLifecycle;
using System.Linq;
using VisionHub.View;
using VisionHub.ViewModel;
using Windows.ApplicationModel.Activation;
using Windows.Storage;

namespace VisionHub
{
    public partial class App : Application
    {
        private Window _window;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.
                AddSingleton<MainWindowViewModel>().
                AddSingleton<ExternalWindowViewModel>();

            Ioc.Default.ConfigureServices(services.BuildServiceProvider());
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            AppInstance instance = AppInstance.GetCurrent();
            AppActivationArguments activationArgs = AppInstance.GetCurrent().GetActivatedEventArgs();

            _window = new MainWindow();
            _window.ExtendsContentIntoTitleBar = true;

            if (activationArgs.Data is FileActivatedEventArgs fileArgs)
            {
                StorageFile file = fileArgs.Files.FirstOrDefault() as StorageFile;

                if (file != null)
                {
                    ((ExternalWindow)_window).ViewModel.OpenViewWithFile(file);
                }
            }
            _window.Activate();
        }
    }
}
