using Ninject;
using ProjectTimeManager.Ninject;
using ProjectTimeManager.ViewModels;
using ProjectTimeManager.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectTimeManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public void App_Startup(object sender, StartupEventArgs e)
        {
            var kernel = new StandardKernel(new NinjectBindings());
            var projectTimeManagerViewModel = kernel.Get<ProjectTimeManagerViewModel>();
            var mainWindow = new ProjectTimeManagerWindow(projectTimeManagerViewModel);
            mainWindow.Show();
        }
    }
}
