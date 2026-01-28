using System.Configuration;
using System.Data;
using System.Windows;
using TaskTracker_WPF.Models;
using TaskTracker_WPF.Services;
using TaskTracker_WPF.Stores;
using TaskTracker_WPF.ViewModels;

namespace TaskTracker_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly TaskBook _taskBook;
        private readonly NavigationStore _navigationStore;
        private readonly SaveLoadService _saveLoadService;
        private readonly TaskIndexStore _taskIndexStore;

        public App()
        {
            _navigationStore = new NavigationStore();
            _saveLoadService = new SaveLoadService();
            _taskIndexStore = new TaskIndexStore();

            _taskBook = _saveLoadService.LoadAsync().Result;
            if (_taskBook == null)
            {
                _taskBook = new TaskBook("Work related");
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            //TaskBook taskBook = new TaskBook("someone");

            //taskBook.AddTask(new DailyTask("taskTitle", "taskDescription", false, new DateOnly(2026, 1, 12)));
            //taskBook.AddTask(new DailyTask("taskTitle1", "taskDescription1", false, new DateOnly(2026, 1, 13)));
            //taskBook.AddTask(new DailyTask("taskTitle2", "taskDescription2", false, new DateOnly(2026, 1, 12)));

            //List<Day> dailyTask = taskBook.ViewTask(new DateOnly(2026, 1, 12));

            //initial startup manual set the starting view
            //_navigationStore.CurrentViewModel = new TaskListingViewModel(_navigationStore, CreateCreateTaskViewModel);
            _navigationStore.CurrentViewModel = CreateTaskListingViewModel();

            //since mainviewmodel will control which view to display, here we will pass in the navigation store into it
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            //load data



            //manually doing startup
            MainWindow.Show();
            
            base.OnStartup(e);
        }

        // a function that returns a new CreateTaskListViewModel object
        private CreateTaskViewModel CreateCreateTaskViewModel()
        {
            return new CreateTaskViewModel(_taskBook, new NavigationService(_navigationStore, CreateTaskListingViewModel), _saveLoadService, _taskIndexStore);
        }

        // a function that returns a new TaskListingViewModel
        private TaskListingViewModel CreateTaskListingViewModel()
        {
            return new TaskListingViewModel(_taskBook, new NavigationService(_navigationStore, CreateCreateTaskViewModel), new ParameterNavigationService<DailyTask, UpdateTaskViewModel>(_navigationStore, CreateUpdateTaskListingViewModel));
        }

        // a function that returns a new UpdateTaskListingViewModel
        private UpdateTaskViewModel CreateUpdateTaskListingViewModel(DailyTask dailyTask)
        {
            return new UpdateTaskViewModel(_taskBook, new NavigationService(_navigationStore, CreateTaskListingViewModel), _saveLoadService, dailyTask);
        }

    }

}
