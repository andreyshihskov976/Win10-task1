using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Win10_task1.Models;
using Win10_task1.Services.DataServices;

namespace Win10_task1.ViewModels
{
    class MainWorkspaceViewModel : BaseViewModel
    {
        #region COMMANDS
        public ICommand AddProcessCommand { get; private set; }
        public ICommand UpdateProcessCommand { get; private set; }
        public ICommand DeleteProcessCommand { get; private set; }
        #endregion COMMAND

        private IForeignDataService<Process> _processRepository;

        private IForeignDataService<SubTask> _subTaskRepository;
        private User _loggedInUser;

        private Process _selectedProcess;

        public MainWorkspaceViewModel(User user)
        {
            _loggedInUser = user;
            _processRepository = new ProcessService();
            _subTaskRepository = new SubTaskService();
            this.PropertyChanged += MainWindowViewModel_PropertyChanged;
            LoadProcesess();
        }

        public MainWorkspaceViewModel()
        {
            _processRepository = new ProcessService();
            _subTaskRepository = new SubTaskService();
            this.PropertyChanged += MainWindowViewModel_PropertyChanged;
            LoadProcesess();
        }

        public Process SelectedProcess
        {
            get { return _selectedProcess; }
            set
            {
                if (_selectedProcess == value)
                    return;
                _selectedProcess = value;
                OnPropertyChanged(nameof(SelectedProcess));
            }
        }

        private ObservableCollection<Process> _processCollection = new ObservableCollection<Process>();

        public ObservableCollection<Process> ProcessCollection
        {
            get { return _processCollection; }
            set
            {
                if (_processCollection == value)
                    return;
                _processCollection.CollectionChanged -= ProcessCollection_CollectionChanged;
                foreach (var item in _processCollection)
                    item.PropertyChanged -= ProcessCollectionItem_PropertyChanged;
                _processCollection = value;
                foreach (var item in _processCollection)
                    item.PropertyChanged += ProcessCollectionItem_PropertyChanged;
                _processCollection.CollectionChanged += ProcessCollection_CollectionChanged;
                OnPropertyChanged(nameof(ProcessCollection));
            }
        }

        private async void ProcessCollectionItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            await Task.Run(() => { _processRepository.Update((Process)sender); });
        }

        private async void ProcessCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (Process item in e.NewItems)
                    {
                        await Task.Run(() => { _processRepository.Create(item, _loggedInUser.Id); });
                        item.PropertyChanged += ProcessCollectionItem_PropertyChanged;
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (Process item in e.OldItems)
                    {
                        item.PropertyChanged -= ProcessCollectionItem_PropertyChanged;
                        await Task.Run(() => { _processRepository.Delete(item); });
                    }
                    break;
                default:
                    break;
            }
        }

        private ObservableCollection<SubTask> _subTaskCollection = new ObservableCollection<SubTask>();

        public ObservableCollection<SubTask> SubTaskCollection
        {
            get { return _subTaskCollection; }
            set
            {
                if (_subTaskCollection == value)
                    return;
                _subTaskCollection.CollectionChanged -= SubTasksCollection_CollectionChanged;
                foreach (var item in _subTaskCollection)
                    item.PropertyChanged -= SubTasksItem_PropertyChanged;
                _subTaskCollection = value;
                foreach (var item in _subTaskCollection)
                    item.PropertyChanged += SubTasksItem_PropertyChanged;
                _subTaskCollection.CollectionChanged += SubTasksCollection_CollectionChanged;
                OnPropertyChanged(nameof(SubTaskCollection));
            }
        }

        private async void SubTasksItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            await Task.Run(() => { _subTaskRepository.Update((SubTask)sender); });
        }

        private async void SubTasksCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (SubTask item in e.NewItems)
                    {
                        await Task.Run(() => { _subTaskRepository.Create(item, SelectedProcess.Id); });
                        item.PropertyChanged += SubTasksItem_PropertyChanged;
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (SubTask item in e.OldItems)
                    {
                        item.PropertyChanged -= SubTasksItem_PropertyChanged;
                        await Task.Run(() => { _subTaskRepository.Delete(item); });
                    }
                    break;
                default:
                    break;
            }
        }

        private void MainWindowViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedProcess) && SelectedProcess != null)
                LoadSubTasks();
        }

        private async void LoadProcesess()
        {
            ProcessCollection = new ObservableCollection<Process>(await _processRepository.GetListById(_loggedInUser.Id));
        }

        public async void LoadSubTasks()
        {
            SubTaskCollection = new ObservableCollection<SubTask>(await _subTaskRepository.GetListById(SelectedProcess.Id));
        }
    }
}
