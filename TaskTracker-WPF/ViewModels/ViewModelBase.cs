using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker_WPF.ViewModels
{
    class ViewModelBase : INotifyPropertyChanged
    {
        //this inherited interface is something views will hook to, meaning will look towards this propertyChanged event for updates
        //regarding any changes to the data binding and when to change
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) //call this function whenever a property is changed
        {
            //"publish" out the event
            //this event is  subscribed by the UI (UpdateSourceTrigger=PropertyChanged)
            //so can be triggered by viewmodel anytime the values has been changed to reflect it properly
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
