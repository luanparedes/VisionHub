using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VisionHub.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace VisionHub.View
{
    public sealed partial class ExternalWindow : Window
    {
        public ExternalWindowViewModel ViewModel { get; }

        public ExternalWindow()
        {
            this.InitializeComponent();
            ViewModel = Ioc.Default.GetService<ExternalWindowViewModel>();
        }
    }
}
