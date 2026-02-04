
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskTracker_WPF.Models
{
    internal class DailyTask
    {
        public int taskIndex { get; set; }
        public string taskTitle { get; set; }
        public string taskDescription { get; set; }
        public DateTime dayOfDate { get; set; }
        public bool taskCompletion { get; set; }

        [JsonInclude]
        private List<SubTask> _subTaskList;

        public DailyTask(int taskIndex, string taskTitle, string taskDescription, DateTime dayOfDate, bool taskCompletion)
        {
            _subTaskList = new List<SubTask>();
            this.taskIndex = taskIndex;
            this.taskTitle = taskTitle;
            this.taskDescription = taskDescription;
            this.dayOfDate = dayOfDate;
            this.taskCompletion = taskCompletion;
        }

        //for actual add new subtask
        public void AddSubTask(string subTaskTitle, bool subTaskCompletion)
        {
            _subTaskList.Add(new SubTask(GetIncrementalSubTaskIndex(), subTaskTitle, subTaskCompletion));
        }
        //for pre-existing subtask <-> subtaskviewmodel
        public void AddSubTask(int subTaskIndex, string subTaskTitle, bool subTaskCompletion)
        {
            _subTaskList.Add(new SubTask(subTaskIndex, subTaskTitle, subTaskCompletion));
        }

        public void UpdateSubTask(SubTask subTask)
        {
            int _subTaskIndex = _subTaskList.FindIndex(sub =>
            {
                return sub.subTaskIndex.Equals(subTask.subTaskIndex);
            });

            if (_subTaskIndex != -1)
            {
                _subTaskList[_subTaskIndex] = subTask;
            }
        }

        public void RemoveSubTask(SubTask subTask)
        {
            int _subTaskIndex = _subTaskList.FindIndex(sub =>
            {
                return sub.subTaskIndex.Equals(subTask.subTaskIndex);
            });

            if (_subTaskIndex != -1)
            {
                _subTaskList.RemoveAt(_subTaskIndex);
            }
        }

        private int GetIncrementalSubTaskIndex()
        {
            int subIndex = 0;

            //get last item on the list and increment that index by 1
            if (_subTaskList.Count != 0)
            {
               subIndex = _subTaskList[_subTaskList.Count - 1].subTaskIndex + 1;
            }
            //if no item in list, remain as 0 = first item on list

            return subIndex;
        }

        public List<SubTask> GetSubTasks()
        {
            return _subTaskList;
        }

        public void ClearSubTaskList()
        {
            _subTaskList.Clear();
        }

    }
}
