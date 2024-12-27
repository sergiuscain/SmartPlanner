using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlannerDb.Entities
{
    public class TaskModel
    {
        public Guid TaskModelId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime Deadline { get; set; }
        public List<SubTask> SubTasks { get; set; }

        //Навигационные свойства:
        public User User { get; set; }
    }
}
