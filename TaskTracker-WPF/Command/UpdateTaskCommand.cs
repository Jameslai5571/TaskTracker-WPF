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
    internal class UpdateTaskCommand : CommandBase
    {
        private TaskBook _taskBook;
        private readonly NavigationService _taskViewNavigationService;
        private readonly SaveLoadService _saveLoadService;
        private readonly DailyTask _dailyTask;
        private readonly UpdateTaskViewModel _updateTaskViewModel;

        public UpdateTaskCommand(UpdateTaskViewModel updateTaskViewModel, TaskBook taskBook,
            NavigationService taskViewNavigationService, SaveLoadService saveLoadService, DailyTask dailyTask)
        {
            _taskBook = taskBook;
            _taskViewNavigationService = taskViewNavigationService;
            _saveLoadService = saveLoadService;
            _dailyTask = dailyTask;
            _updateTaskViewModel = updateTaskViewModel;
        }


        public override void Execute(object? parameter)
        {
            //====
            //clear old list
            _dailyTask.ClearSubTaskList();
            //add in all items into list
            foreach (SubTaskViewModel subTaskVM in this._updateTaskViewModel.SubTasks)
            {
                _dailyTask.AddSubTask(subTaskVM.SubTaskIndex, subTaskVM.SubTaskTitle, subTaskVM.SubTaskCompletion);
            }


            //perform changes & uppdate
            _taskBook.UpdateTask(_dailyTask);

            _saveLoadService.SaveAsync(_taskBook);

            _taskViewNavigationService.Navigate();
        }
    }
}
