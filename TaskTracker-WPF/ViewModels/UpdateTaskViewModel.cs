using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskTracker_WPF.Command;
using TaskTracker_WPF.Models;
using TaskTracker_WPF.Services;

namespace TaskTracker_WPF.ViewModels
{
    internal class UpdateTaskViewModel : ViewModelBase
    {
        private DailyTask _dailyTask;

        private DateTime _dayOfDate;
        //these public ones will be the binding name for those in the View, so the binding name in View must match those of in ViewModel
        public DateTime DateOfDay
        {
            get
            {
                return _dailyTask.dayOfDate;
            }
            set
            {
                _dailyTask.dayOfDate = value;
                OnPropertyChanged(nameof(DateOfDay));
            }
        }

        private string _taskTitle;

        public string TaskTitle
        {
            get
            {
                return _dailyTask.taskTitle;
            }
            set
            {
                _dailyTask.taskTitle = value;
                OnPropertyChanged(nameof(TaskTitle));
            }
        }

        private string _taskDescription;

        public string TaskDescription
        {
            get
            {
                return _dailyTask.taskDescription;
            }
            set
            {
                _dailyTask.taskDescription = value;
                OnPropertyChanged(nameof(TaskDescription));
            }
        }

        private bool _taskCompletion;

        public bool TaskCompletion
        {
            get
            {
                return _dailyTask.taskCompletion;
            }
            set
            {
                _dailyTask.taskCompletion = value;
                OnPropertyChanged(nameof(TaskCompletion));
            }
        }

        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand CancelCommand { get; }

        //getting a function to create a new TaskListingViewModel here for the create & cancel command to navigate back to the correct view
        public UpdateTaskViewModel(TaskBook taskBook, NavigationService taskListingNavigationService, SaveLoadService saveLoadService, DailyTask dailyTask)
        {
            _dailyTask = dailyTask;

            UpdateCommand = new UpdateTaskCommand(taskBook, taskListingNavigationService, saveLoadService, _dailyTask);
            DeleteCommand = new DeleteTaskCommand(taskBook, taskListingNavigationService, saveLoadService, _dailyTask);
            CancelCommand = new NavigateCommand(taskListingNavigationService);
        }



    }
}
