
namespace SmartPlanner.Models
{
    public class ProjectViewModel
    {
        public Guid ProjectId { get; set; } // Уникальный идентификатор проекта
        public string UserId { get; set; } // Идентификатор пользователя, которому принадлежит проект
        public string Title { get; set; } // Заголовок проекта
        public string Description { get; set; } // Описание проекта
        public DateTime DateOfCreation { get; set; } // Дата создания проекта
        public DateTime Deadline { get; set; } // Дедлайн проекта

        // Списки связанных моделей
        public List<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>(); // Список задач
        public List<NoteViewModel> Notes { get; set; } = new List<NoteViewModel>(); // Список заметок
        public List<GoalViewModel> Goals { get; set; } = new List<GoalViewModel>(); // Список целей
    }
}
