using ProjectTimeManager.ViewModels;

namespace ProjectTimeManager.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ProjectTimeManagerWindow
    {
        public ProjectTimeManagerWindow(ProjectTimeManagerViewModel projectTimeManagerViewModel)
        {
            InitializeComponent();
            this.DataContext = projectTimeManagerViewModel;
        }
    }
}
