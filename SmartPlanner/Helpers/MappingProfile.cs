using SmartPlanner.Models;
using SmartPlannerDb.Entities;

namespace SmartPlanner.Helpers
{
    public static class MappingProfile
    {
        public static NoteViewModel ToViewModel(this Note model)
        {
            var viewModel = new NoteViewModel
            {
                NoteId = model.NoteId,
                Description = model.Description,
                Title = model.Title,
                UserId = model.UserId,
            };
            if (model.ProjectId != null)
            {
                viewModel.ProjectId = model.ProjectId;
            }
            return viewModel;
        }
        public static List<NoteViewModel> ToViewModel(this List<Note> notes)
        {
            return notes.Select(n => n.ToViewModel()).ToList();
        }
        public static Note ToDbModel(this NoteViewModel model)
        {
            var dBModel = new Note
            {
                NoteId = model.NoteId,
                Description = model.Description,
                Title = model.Title,
                UserId = model.UserId,
            };
            if (model.ProjectId != null)
            {
                dBModel.ProjectId = model.ProjectId;
            }
            return dBModel;
        }
        public static List<Note> ToDbModel(this List<NoteViewModel> notes)
        {
            return notes.Select(n => n.ToDbModel()).ToList();
        }
        public static TaskViewModel ToViewModel(this TaskModel model)
        {
            var viewModel = new TaskViewModel
            {
                TaskModelId = model.TaskModelId,
                UserId = model.UserId,
                Title = model.Title,
                Description = model.Description,
                DateOfCreation = model.DateOfCreation,
                Deadline = model.Deadline,
                Priority = model.Priority,
                Status = model.Status,
                User = model.User,
                SubTasks = model.SubTasks.Select(subTask => subTask.ToViewModel()).ToList()
            };
            if (model.ProjectId != null)
            {
                viewModel.ProjectId = model.ProjectId;
            }
            return viewModel;
        }
        public static List<TaskViewModel> ToViewModel(this List<TaskModel> tasks)
        {
            return tasks.Select(t => t.ToViewModel()).ToList();
        }
        public static TaskModel ToDbModel(this TaskViewModel model)
        {
            var taskDB = new TaskModel
            {
                TaskModelId = model.TaskModelId,
                UserId = model.UserId,
                Title = model.Title,
                Description = model.Description,
                DateOfCreation = model.DateOfCreation,
                Deadline = model.Deadline,
                Priority = model.Priority,
                Status = model.Status,
                User = model.User,
                SubTasks = model.SubTasks.Select(subTask => subTask.ToDbModel()).ToList()
            };
            taskDB.SubTasks.ForEach(subTask => subTask.TaskId = model.TaskModelId);
            if (model.ProjectId != null)
            {
                taskDB.ProjectId = model.ProjectId;
            }
            return taskDB;
        }
        public static List<TaskModel> ToDbModel(this List<TaskViewModel> tasks)
        {
            return tasks.Select(t => t.ToDbModel()).ToList();
        }
        public static SubTask ToDbModel(this SubTaskViewModel model)
        {
            return new SubTask
            {
                Description = model.Description,
                Title = model.Title,
                SubTaskId = model.SubTaskId,
                TaskId = model.TaskId,
            };
        }
        public static SubTaskViewModel ToViewModel(this SubTask model)
        {
            return new SubTaskViewModel
            {
                Description = model.Description,
                Title = model.Title,
                SubTaskId = model.SubTaskId,
                TaskId = model.TaskId,
            };
        }
        public static GoalViewModel ToViewModel(this Goal model)
        {
            var viewModel = new GoalViewModel
            {
                Id = model.Id,
                Description = model.Description,
                CurrentProgress = model.CurrentProgress,
                TotalProgress = model.TotalProgress,
                UserId = model.UserId,
            };
            if (model.ProjectId != null)
            {
                viewModel.ProjectId = model.ProjectId;
            }
            return viewModel;
        }
        public static List<GoalViewModel> ToViewModel(this List<Goal> goals)
        {
            return goals.Select(t => t.ToViewModel()).ToList();
        }
        public static Goal ToDbModel(this GoalViewModel model)
        {
            var dBModel = new Goal
            {
                Id = model.Id,
                Description = model.Description,
                CurrentProgress = model.CurrentProgress,
                TotalProgress = model.TotalProgress,
                UserId = model.UserId,
            };
            if (model.ProjectId != null)
            {
                dBModel.ProjectId = model.ProjectId;
            }
            return dBModel;
        }
        public static List<Goal> ToDbModel(this List<GoalViewModel> goals)
        {
            return goals.Select(g => g.ToDbModel()).ToList();
        }
        public static ProjectViewModel ToViewModel(this Project model)
        {
            if (model.Tasks == null)
                model.Tasks = new();
            if (model.Goals == null)
                model.Goals = new();
            if (model.Notes == null)
                model.Notes = new();

            return new ProjectViewModel
            {
                ProjectId = model.ProjectId,
                UserId = model.UserId,
                Title = model.Title,
                Description = model.Description,
                DateOfCreation = model.DateOfCreation,
                Deadline = model.Deadline,
                Goals = model.Goals.ToViewModel(),
                Notes = model.Notes.ToViewModel(),
                Tasks = model.Tasks.ToViewModel(),
            };
        }
        public static List<ProjectViewModel> ToViewModel(this List<Project> projects)
        {
            return projects.Select(p => p.ToViewModel()).ToList();
        }
        public static Project ToDbModel(this ProjectViewModel model)
        {
            if (model.Tasks == null)
                model.Tasks = new();
            if (model.Goals == null)
                model.Goals = new();
            if (model.Notes == null)
                model.Notes = new();

            return new Project
            {
                ProjectId = model.ProjectId,
                UserId = model.UserId,
                Title = model.Title,
                Description = model.Description,
                DateOfCreation = model.DateOfCreation,
                Deadline = model.Deadline,
                Goals = model.Goals.ToDbModel(),
                Notes = model.Notes.ToDbModel(),
                Tasks = model.Tasks.ToDbModel(),
            };
        }
        public static List<Project> ToViewModel(this List<ProjectViewModel> projects)
        {
            return projects.Select(p => p.ToDbModel()).ToList();
        }
    }
}
