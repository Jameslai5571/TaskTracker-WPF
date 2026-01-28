using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskTracker_WPF.Command;
using TaskTracker_WPF.Models;
using TaskTracker_WPF.Services;
using TaskTracker_WPF.Stores;

namespace TaskTracker_WPF.ViewModels
{
    class TaskListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<DailyTaskViewModel> _dailyTasks;

        private readonly TaskBook _taskBook;
        //expose the properties for retreival by the view
        //observable collection implement INotifyCollectionChanged, so any changes to the collection will receive an update to the list view
        // => used because the collection will change based on user input, also no static
        //public ObservableCollection<DailyTaskViewModel> DailyTask => _dailyTask;
        //encapsulation, allow view to reiterating over the collection only
        public IEnumerable<DailyTaskViewModel> DailyTasks => _dailyTasks;

        private readonly Week _week;

        public DateTime WeekStartDate => _taskBook.GetDateTimes()[0];
        public DateTime WeekEndDate => _taskBook.GetDateTimes()[1];

        public ICommand AddTaskCommand { get; }

        public ICommand EditTaskCommand { get; }

        //getting a function that can create a new CreateTaskViewModel for when accessing the Add Task button
        public TaskListingViewModel(TaskBook taskBook, NavigationService createTaskListingNavigationService, ParameterNavigationService<DailyTask, UpdateTaskViewModel> updateTaskListingNavigationService)
        {
            _taskBook = taskBook;
            
            //_week

            _dailyTasks = new ObservableCollection<DailyTaskViewModel>();

            AddTaskCommand = new NavigateCommand(createTaskListingNavigationService);
            //EditTaskCommand = new RelayCommand<DailyTask>(EditTask);

            //the parameter is received from the CommandParameter binding, in this case the dailyTask is the param binding
            //CommandParameter="{Binding}" → binds to the current data context of the item, aka DailyTask here
            EditTaskCommand = new RelayCommand<DailyTaskViewModel>(dailyTaskViewModel =>
            {
                DailyTask dailyTask = new DailyTask(
                    dailyTaskViewModel.TaskIndex,
                    dailyTaskViewModel.TaskTitle, 
                    dailyTaskViewModel.TaskDescription, 
                    DateTime.Parse(dailyTaskViewModel.DayOfDate),
                    dailyTaskViewModel.TaskCompletion);

                new NavigateCommand(updateTaskListingNavigationService, dailyTask).Execute(dailyTask);
            });

            //_dailyTasks.Add(new DailyTaskViewModel(new DailyTask("taskTitle", "taskDescription", DateTime.Now, true)));
            //_dailyTasks.Add(new DailyTaskViewModel(new DailyTask("taskTitle1", "taskDescription1", DateTime.Now, false)));
            //_dailyTasks.Add(new DailyTaskViewModel(new DailyTask("taskTitle2", "taskDescription2", DateTime.Now, false)));

            //since a new view model is create whenever the view is accessed, performing this update to pull the latest information
            //into a internal collection for displaying
            UpdateTaskListing();

        }

        private void UpdateTaskListing()
        {
            _dailyTasks.Clear();

            foreach (DailyTask dailyTask in _taskBook.ViewTask())
            {
                //do this here because the list to be accessed by the view is looking for item with class DailyTaskViewModel
                //not the Model class itself, see DailyTaskViewModel class for notes
                DailyTaskViewModel dailyTaskViewModel = new DailyTaskViewModel(dailyTask);

                _dailyTasks.Add(dailyTaskViewModel); 
            }

        }
    }
}
