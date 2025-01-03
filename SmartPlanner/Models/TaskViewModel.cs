using SmartPlannerDb.Entities;

namespace SmartPlanner.Models
{
    public class TaskViewModel
    {
        public Guid TaskModelId { get; set; }
        public string UserId { get; set; }
        public Guid? ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime Deadline { get; set; }
        public List<SubTaskViewModel> SubTasks { get; set; }

        //Навигационные свойства:
        public User User { get; set; }
    }
}
