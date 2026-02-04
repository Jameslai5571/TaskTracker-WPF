using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskTracker_WPF.Command;
using TaskTracker_WPF.Models;

namespace TaskTracker_WPF.ViewModels
{
    class DailyTaskViewModel : ViewModelBase
    {
        //this view model is to help bridge between the TaskListingViewModel & DailyTask model
        //this will help prevent the viewmodel from directly interacting with the model it self

        private readonly DailyTask _dailyTask;

        //helps to give the view the model properties only
        //Expression-bodied members (https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members)
        //is computed/calculated each time when accessed
        public int TaskIndex => _dailyTask.taskIndex;
        public string TaskTitle => _dailyTask.taskTitle;
        public string TaskDescription => _dailyTask.taskDescription;
        public string DayOfDate => _dailyTask.dayOfDate.ToString("d");
        public bool TaskCompletion => _dailyTask.taskCompletion;

        private readonly ObservableCollection<SubTaskViewModel> _subTaskViewModels;
        public IEnumerable<SubTaskViewModel> SubTasks => _subTaskViewModels;

        public DailyTaskViewModel(DailyTask dailyTask)
        {
            _dailyTask = dailyTask;

            _subTaskViewModels = new ObservableCollection<SubTaskViewModel>();

            foreach (SubTask subTask in _dailyTask.GetSubTasks())
            {
                _subTaskViewModels.Add(new SubTaskViewModel(subTask));
            }
        }

    }
}
