using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskTracker_WPF.Models
{
    internal class TaskBook
    {

        //because this is readonly, we will need to setup a different constructor for the specific
        //so that during deserialization it will be able to properly set the values from jsonfile
        [JsonInclude]
        private readonly Week _week;

        public string name { get; }

        //due to readonly, need a specified constructor for it, the input parameter name must match with those written into json file
        [JsonConstructor]
        public TaskBook(Week _week, string name) =>
            (this._week, this.name) = (_week, name);
        //json specfic constructor, bcause the Week is readonly
        //constructor => (object properties) = (constructor parameters) 
        //  expression-bodied constructor, Tuple-style assignment
        //[JsonConstructor]
        //public TaskBook(Week _week, string name)
        //{
        //    this._week = _week;
        //    this.name = name;
        //}


        public TaskBook(string Name)
        {
            this.name = Name;

            //temp
            _week = new Week(new DateTime(2026,1,19));
        }


        public List<DailyTask> ViewTask()
        {
            return _week.GetTask();
        }
        public void AddTask(DailyTask dailyTask)
        {
            _week.AddTask(dailyTask);
        }
        public void UpdateTask(DailyTask dailyTask)
        {
            _week.UpdateTask(dailyTask);
        }
        public void RemoveTask(DailyTask dailyTask)
        {
            _week.RemoveTask(dailyTask);
        }

        //temp
        public List<DateTime> GetDateTimes()
        {
            return new List<DateTime>([_week.weekStartDate, _week.weekEndDate]);
        }
    }
}
