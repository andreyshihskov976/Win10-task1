using System.Windows.Controls;

namespace Win10_task1.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWorkspace.xaml
    /// </summary>
    public partial class MainWorkspace : UserControl
    {
        public MainWorkspace(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
