using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_WPF.Models;
using TaskTracker_WPF.Services;
using TaskTracker_WPF.Stores;
using TaskTracker_WPF.ViewModels;

namespace TaskTracker_WPF.Command
{
    internal class CreateTaskCommand : CommandBase
    {
        private readonly TaskBook _taskBook;
        private readonly CreateTaskViewModel _createTaskViewModel;
        private readonly NavigationService _taskViewNavigationService;
        private readonly SaveLoadService _saveLoadService;
        private readonly TaskIndexStore _taskIndexStore;

        public CreateTaskCommand(CreateTaskViewModel createTaskViewModel, TaskBook taskBook,
            NavigationService taskViewNavigationService, SaveLoadService saveLoadService, TaskIndexStore taskIndexStore)
        {
            _createTaskViewModel = createTaskViewModel;
            _taskBook = taskBook;

            _taskViewNavigationService = taskViewNavigationService;

            //the CreateTaskViewModel trigger invoke/publish propertychanged event each time a property within viewmodel is changed
            //here a function subscribes to the PropertyChanged Event
            //the function will triger whenever the event is raised
            _createTaskViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _saveLoadService = saveLoadService;
            _taskIndexStore = taskIndexStore;
        }

        public override bool CanExecute(object? parameter)
        {
            //with this check, will block the create button when this field is empty
            //but only this alone will not check for its change, so subscribing to PropertyChanged and coming back here for another
            //check when PropertyChanged event has been invoked/published
            return !string.IsNullOrEmpty(_createTaskViewModel.TaskTitle) 
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            DailyTask dailyTask = new DailyTask(
                _taskIndexStore.GetTaskIndex(),
                _createTaskViewModel.TaskTitle,
                _createTaskViewModel.TaskDescription,
                _createTaskViewModel.DateOfDay,
                _createTaskViewModel.TaskCompletion);

            _taskBook.AddTask(dailyTask);

            _saveLoadService.SaveAsync(_taskBook);

            _taskViewNavigationService.Navigate();
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            //the propertyname that is sent over the event, refer to ViewModelBase for the arguements sent over via invoking events
            if (e.PropertyName == nameof(CreateTaskViewModel.TaskTitle))
            {
                OnCanExecutedChanged(); 
                //will publish out an event to check whether the button can be executed
                //condition for it is at the function above "CanExecute"
            }
        }
    }
}
