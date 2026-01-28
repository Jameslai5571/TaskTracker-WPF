using System;
using System.Collections.Generic;
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
    class CreateTaskViewModel : ViewModelBase
    {
        //reference
        //private int myVar;

        //public int MyProperty
        //{
        //    get
        //    {
        //        return myVar;
        //    }
        //    set
        //    {
        //        myVar = value;
        //        OnPropertyChanged(nameof(MyProperty));
        //    }
        //}

        private DateTime _dateOfDay = DateTime.Today;

        //these public ones will be the binding name for those in the View, so the binding name in View must match those of in ViewModel
        public DateTime DateOfDay
        {
            get
            {
                return _dateOfDay;
            }
            set
            {
                _dateOfDay = value;
                OnPropertyChanged(nameof(DateOfDay));
            }
        }

        private string _taskTitle;

        public string TaskTitle
        {
            get
            {
                return _taskTitle;
            }
            set
            {
                _taskTitle = value;
                OnPropertyChanged(nameof(TaskTitle));
            }
        }

        private string _taskDescription;

        public string TaskDescription
        {
            get
            {
                return _taskDescription;
            }
            set
            {
                _taskDescription = value;
                OnPropertyChanged(nameof(TaskDescription));
            }
        }

        private bool _taskCompletion;

        public bool TaskCompletion
        {
            get
            {
                return _taskCompletion;
            }
            set
            {
                _taskCompletion = value;
                OnPropertyChanged(nameof(TaskCompletion));
            }
        }

        public ICommand CreateCommand { get; }
        public ICommand CancelCommand { get; }

        //getting a function to create a new TaskListingViewModel here for the create & cancel command to navigate back to the correct view
        public CreateTaskViewModel(TaskBook taskBook, NavigationService taskListingNavigationService, SaveLoadService saveLoadService, TaskIndexStore taskIndexStore)
        {
            CreateCommand = new CreateTaskCommand(this, taskBook, taskListingNavigationService, saveLoadService, taskIndexStore);
            CancelCommand = new NavigateCommand(taskListingNavigationService);
        }

    }
}
