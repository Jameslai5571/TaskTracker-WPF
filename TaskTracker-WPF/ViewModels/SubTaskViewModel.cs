using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_WPF.Models;

namespace TaskTracker_WPF.ViewModels
{
    class SubTaskViewModel : ViewModelBase
    {
        private readonly SubTask _subTask;

        public int SubTaskIndex { get; set; } 
        public string SubTaskTitle { get; set; }
        public bool SubTaskCompletion { get; set; }

        public SubTaskViewModel(SubTask subTask)
        {
            _subTask = subTask;

            SubTaskIndex = _subTask.subTaskIndex;
            SubTaskTitle = _subTask.subTaskTitle;
            SubTaskCompletion = _subTask.subTaskCompletion;
        }
        public SubTaskViewModel()
        {
        }
    }
}
