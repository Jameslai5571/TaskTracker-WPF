using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskTracker_WPF.Models
{
    internal class Week
    {
        [JsonInclude] //included to allow json serialize/deserialize
        private List<DailyTask> _dailyTaskList;

        public DateTime weekStartDate { get; }
        public DateTime weekEndDate { get; }

        public Week(DateTime weekStartDate)
        {
            _dailyTaskList = new List<DailyTask>();
            this.weekStartDate = weekStartDate;
            this.weekEndDate = weekStartDate.AddDays(6);

        }


        public List<DailyTask> GetTask()
        {
            return _dailyTaskList;
        }
        public void AddTask(DailyTask dailyTask)
        {
            _dailyTaskList.Add(dailyTask);
        }

        public void UpdateTask(DailyTask dailyTask)
        {
            //lambda expression
            // parameter => statement & return value
            //find 
            int _taskIndex = _dailyTaskList.FindIndex(daily =>
            {
                return daily.taskIndex.Equals(dailyTask.taskIndex);
            });

            if (_taskIndex != -1)
            {
                _dailyTaskList[_taskIndex] = dailyTask;
            }
        }

        public void RemoveTask(DailyTask dailyTask)
        {
            int _taskIndex = _dailyTaskList.FindIndex(daily =>
            {
                return daily.taskIndex.Equals(dailyTask.taskIndex);
            });

            if (_taskIndex != -1)
            {
                _dailyTaskList.RemoveAt(_taskIndex);
            }
        }
    }
}
