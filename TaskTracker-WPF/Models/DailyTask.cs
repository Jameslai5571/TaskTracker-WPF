
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker_WPF.Models
{
    internal class DailyTask
    {
        //temp removal, once the overall app comes together, will add in future
        //private List<SubTask> _subTasks;

        public int taskIndex { get; set; }
        public string taskTitle { get; set; }
        public string taskDescription { get; set; }
        public DateTime dayOfDate { get; set; }
        public bool taskCompletion { get; set; }

        public DailyTask(int taskIndex, string taskTitle, string taskDescription, DateTime dayOfDate, bool taskCompletion)
        {
            //_subTasks = new List<SubTask>();
            this.taskIndex = taskIndex;
            this.taskTitle = taskTitle;
            this.taskDescription = taskDescription;
            this.dayOfDate = dayOfDate;
            this.taskCompletion = taskCompletion;
        }

        public void UpdateTaskCompletion()
        {
            this.taskCompletion = !taskCompletion;
        }

        public void UpdateTaskInfo(string taskTitle, string taskDescription, DateTime dayOfDate, bool taskCompletion)
        {
            this.taskTitle = taskTitle;
            this.taskDescription = taskDescription;
            this.dayOfDate = dayOfDate;
            this.taskCompletion = taskCompletion;
        }

        //public void AddSubTask(string subTaskTitle, string subTaskDescription)
        //{
        //    _subTasks.Add(new SubTask(subTaskTitle, subTaskDescription, false));
        //}

    }
}
