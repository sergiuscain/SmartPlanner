using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlannerDb.Entities
{
    public class Project
    {
        public Guid ProjectId { get; set; } // Уникальный идентификатор проекта
        public string UserId { get; set; } // Идентификатор пользователя, которому принадлежит проект
        public string Title { get; set; } // Заголовок проекта
        public string Description { get; set; } // Описание проекта
        public DateTime DateOfCreation { get; set; } // Дата создания проекта
        public DateTime Deadline { get; set; } // Дедлайн проекта

        // Списки связанных моделей
        public List<TaskModel> Tasks { get; set; } // Список задач
        public List<Note> Notes { get; set; } // Список заметок
        public List<Goal> Goals { get; set; } // Список целей

        // Навигационные свойства
        public User User { get; set; } // Связь с пользователем
    }
}
