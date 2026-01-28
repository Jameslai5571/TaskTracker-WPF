using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_WPF.ViewModels;

namespace TaskTracker_WPF.Stores
{
    //a Store's purpose is to maintain a singular truth of a specific item for the entire application
    //akin to a State Machine Manager

    //purpose of this store is to maintain the current view model
    internal class NavigationStore
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                //trigger event
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }


    }
}
