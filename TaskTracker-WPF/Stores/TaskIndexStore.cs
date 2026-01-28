using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker_WPF.Stores
{
    internal class TaskIndexStore
    {
        private int _taskIndex;
        private string _fileName = "TaskIndex.txt";

        public TaskIndexStore()
        {
            //index starts at 1, initialized as 0 here since following function will perform increment
            _taskIndex = 0;

            if (File.Exists(_fileName))
            {
                string contentString = File.ReadAllText(_fileName);
                _taskIndex = int.Parse(contentString);
            }
            else
            {
                File.Create(_fileName).Close();
            }
            
        }

        public int GetTaskIndex()
        {
            _taskIndex++;

            File.WriteAllText(_fileName, _taskIndex.ToString());

            return _taskIndex;
        }
    }
}
