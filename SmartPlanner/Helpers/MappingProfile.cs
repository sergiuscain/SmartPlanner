using SmartPlanner.Models;
using SmartPlannerDb.Entities;

namespace SmartPlanner.Helpers
{
    public static class MappingProfile
    {
        public static NoteViewModel ToViewModel(this Note note)
        {
            return new NoteViewModel
            {
                NoteId = note.NoteId,
                Description = note.Description,
                Title = note.Title,
                UserId = note.UserId,
            };
        }
        public static List<NoteViewModel> ToViewModel(this List<Note> notes)
        {
            return notes.Select(n => n.ToViewModel()).ToList();
        }
        public static Note ToDbModel(this NoteViewModel note)
        {
            return new Note
            {
                NoteId = note.NoteId,
                Description = note.Description,
                Title = note.Title,
                UserId = note.UserId,
            };
        }
        public static List<Note> ToDbModel(this List<NoteViewModel> notes)
        {
            return notes.Select(n => n.ToDbModel()).ToList();
        }
        public static TaskViewModel ToViewModel(this TaskModel task)
        {
            return new TaskViewModel
            {
                TaskModelId = task.TaskModelId,
                UserId = task.UserId,
                Title = task.Title,
                Description = task.Description,
                DateOfCreation = task.DateOfCreation,
                Deadline = task.Deadline,
                Priority = task.Priority,
                Status = task.Status,
                User = task.User,
                SubTasks = task.SubTasks.Select(subTask => subTask.ToViewModel()).ToList()
            };
        }
        public static List<TaskViewModel> ToViewModel(this List<TaskModel> tasks)
        {
            return tasks.Select(t => t.ToViewModel()).ToList();
        }
        public static TaskModel ToDbModel(this TaskViewModel task)
        {
            var taskDB = new TaskModel
            {
                TaskModelId = task.TaskModelId,
                UserId = task.UserId,
                Title = task.Title,
                Description = task.Description,
                DateOfCreation = task.DateOfCreation,
                Deadline = task.Deadline,
                Priority = task.Priority,
                Status = task.Status,
                User = task.User,
                SubTasks = task.SubTasks.Select(subTask => subTask.ToDbModel()).ToList()
            };
            taskDB.SubTasks.ForEach(subTask => subTask.TaskId = task.TaskModelId);
            return taskDB;
        }
        public static List<TaskModel> ToDbModel(this List<TaskViewModel> tasks)
        {
            return tasks.Select(t => t.ToDbModel()).ToList();
        }
        public static SubTask ToDbModel(this SubTaskViewModel subTask)
        {
            return new SubTask
            {
                Description = subTask.Description,
                Title = subTask.Title,
                SubTaskId = subTask.SubTaskId,
                TaskId = subTask.TaskId,
            };
        }
        public static SubTaskViewModel ToViewModel(this SubTask subTask)
        {
            return new SubTaskViewModel
            {
                Description = subTask.Description,
                Title = subTask.Title,
                SubTaskId = subTask.SubTaskId,
                TaskId = subTask.TaskId,
            };
        }
        public static GoalViewModel ToViewModel(this Goal goal)
        {
            return new GoalViewModel
            {
                Id = goal.Id,
                Description = goal.Description,
                CurrentProgress = goal.CurrentProgress,
                TotalProgress = goal.TotalProgress,
                UserId = goal.UserId,
            };
        }
        public static List<GoalViewModel> ToViewModel(this List<Goal> goals)
        {
            return goals.Select(t => t.ToViewModel()).ToList();
        }
        public static Goal ToDbModel(this GoalViewModel goal)
        {
            return new Goal
            {
                Id = goal.Id,
                Description = goal.Description,
                CurrentProgress = goal.CurrentProgress,
                TotalProgress = goal.TotalProgress,
                UserId = goal.UserId,
            };
        }
        public static List<Goal> ToDbModel(this List<GoalViewModel> goals)
        {
            return goals.Select(g => g.ToDbModel()).ToList();
        }
    }
}
