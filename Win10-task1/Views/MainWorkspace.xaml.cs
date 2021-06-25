using System.Windows.Controls;
using Win10_task1.ViewModels;

namespace Win10_task1.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWorkspace.xaml
    /// </summary>
    public partial class MainWorkspace : UserControl
    {
        public MainWorkspace()
        {
            InitializeComponent();
            DataContext = new MainWorkspaceViewModel();
        }

        public MainWorkspace(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
