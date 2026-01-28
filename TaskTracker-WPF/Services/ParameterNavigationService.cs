using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_WPF.Stores;
using TaskTracker_WPF.ViewModels;

namespace TaskTracker_WPF.Services
{
    internal class ParameterNavigationService<TParameter, TViewModel>
        where TViewModel : ViewModelBase //specify that TViewModel must have/inherit ViewModelBase
        //allow for specification during declarion, on what class parameter it should be taking in, and what class it should be returning out
        //the TParameter & TViewModel here are generics, meaning it can be used however during creation/initliazation
        //so that the following codes can use the same class as those when initialized
    
    {
        private readonly NavigationStore _navigationStore;

        private readonly Func<TParameter, TViewModel> _createViewModel;

        public ParameterNavigationService(NavigationStore navigationStore, Func<TParameter, TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate(TParameter parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel(parameter);
        }

    }
}
