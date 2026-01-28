using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_WPF.Models;
using TaskTracker_WPF.Services;
using TaskTracker_WPF.ViewModels;

namespace TaskTracker_WPF.Command
{
    internal class DeleteTaskCommand : CommandBase  
    {
        private readonly TaskBook _taskBook;
        private readonly NavigationService _taskViewNavigationService;
        private readonly SaveLoadService _saveLoadService;
        private readonly DailyTask _dailyTask;

        public DeleteTaskCommand(TaskBook taskBook,
            NavigationService taskViewNavigationService, SaveLoadService saveLoadService, DailyTask dailyTask)
        {
            _taskBook = taskBook;
            _taskViewNavigationService = taskViewNavigationService;
            _saveLoadService = saveLoadService;
            _dailyTask = dailyTask;
        }


        public override void Execute(object? parameter)
        {
            //perform removal & uppdate
            _taskBook.RemoveTask(_dailyTask);

            _saveLoadService.SaveAsync(_taskBook);

            _taskViewNavigationService.Navigate();
        }
    }
}
