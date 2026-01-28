using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_WPF.Models;
using TaskTracker_WPF.Stores;

namespace TaskTracker_WPF.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;


        //responsible for displaying the current viewmodel of the application
        //public ViewModelBase CurrentViewModel { get; }
        //above is the old code where we manually set it
        //since now it is control dynamically via navigation store, we should retrieve whenever there is a change to its value
        //to properly have the displayed view to be reflected accordingly
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        //below contrusctor is for when manually setting view here & in MainWindow.xaml
        //public MainViewModel(TaskBook taskBook)
        //{
        //    CurrentViewModel = new CreateTaskViewModel(taskBook);
        //}
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
