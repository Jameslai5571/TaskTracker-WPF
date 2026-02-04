using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker_WPF.Models
{
    internal class SubTask
    {
        public int subTaskIndex { get; set; }
        public string subTaskTitle { get; set; }
        public bool subTaskCompletion { get; set; }

        public SubTask(int subTaskIndex, string subTaskTitle, bool subTaskCompletion)
        {
            this.subTaskIndex = subTaskIndex;
            this.subTaskTitle = subTaskTitle;
            this.subTaskCompletion = subTaskCompletion;
        }

    }
}
