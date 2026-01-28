using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskTracker_WPF.Models;
using TaskTracker_WPF.Services;
using TaskTracker_WPF.Stores;
using TaskTracker_WPF.ViewModels;

namespace TaskTracker_WPF.Command
{
    //navigation
    internal class NavigateCommand : CommandBase
    {
        //this function is used for the button to change the currently displayed on screen view

        /* comment to implement NavigationService, allow for easier navigation management & code usage
        private readonly NavigationStore _navigationStore;

        //
        private readonly Func<ViewModelBase> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel; //the expected output here is a class that inherit/is ViewModelBase
        }
        */

        private readonly NavigationService _navigationService;
        private readonly ParameterNavigationService<DailyTask, UpdateTaskViewModel> _parameterNavigationService;
        private DailyTask _dailyTask;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public NavigateCommand(ParameterNavigationService<DailyTask, UpdateTaskViewModel> parameterNavigationService, DailyTask dailyTask)
        {
            _parameterNavigationService = parameterNavigationService;
            _dailyTask = dailyTask;
        }


        public override void Execute(object? parameter)
        {
            //if want to create correct viewmodel for the navigation command, then need to pass in the correct viewmodel when the class is first declared
            //_navigationStore.CurrentViewModel = new CreateTaskViewModel(new Models.TaskBook(""),_navigationStore);

            Debug.WriteLine(parameter);

            //moved to navigationServices
            //_navigationStore.CurrentViewModel = _createViewModel();
            if (_navigationService != null)
            {
                _navigationService.Navigate();
            }
            //after change need notify the MainViewModel to regrab update CurrentViewModel value
            //so in navigation store, trigger event once set has been done
            if (_parameterNavigationService != null)
            {
                _parameterNavigationService.Navigate(_dailyTask);
            }
        }
    }
}
