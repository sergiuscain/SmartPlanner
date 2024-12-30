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
        public static ProjectViewModel ToViewModel(this Project project)
        {
            if (project.Tasks == null)
                project.Tasks = new();
            if (project.Goals == null)
                project.Goals = new();
            if (project.Notes == null)
                project.Notes = new();

            return new ProjectViewModel
            {
                ProjectId = project.ProjectId,
                UserId = project.UserId,
                Title = project.Title,
                Description = project.Description,
                DateOfCreation = project.DateOfCreation,
                Deadline = project.Deadline,
                Goals = project.Goals.ToViewModel(),
                Notes = project.Notes.ToViewModel(),
                Tasks = project.Tasks.ToViewModel(),
            };
        }
        public static List<ProjectViewModel> ToViewModel(this List<Project> projects)
        {
            return projects.Select(p => p.ToViewModel()).ToList();
        }
        public static Project ToDbModel(this ProjectViewModel project)
        {
            if (project.Tasks == null)
                project.Tasks = new();
            if (project.Goals == null)
                project.Goals = new();
            if (project.Notes == null)
                project.Notes = new();

            return new Project
            {
                ProjectId = project.ProjectId,
                UserId = project.UserId,
                Title = project.Title,
                Description = project.Description,
                DateOfCreation = project.DateOfCreation,
                Deadline = project.Deadline,
                Goals = project.Goals.ToDbModel(),
                Notes = project.Notes.ToDbModel(),
                Tasks = project.Tasks.ToDbModel(),
            };
        }
        public static List<Project> ToViewModel(this List<ProjectViewModel> projects)
        {
            return projects.Select(p => p.ToDbModel()).ToList();
        }
    }
}
