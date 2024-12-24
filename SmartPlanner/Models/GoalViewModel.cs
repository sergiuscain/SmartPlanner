using SmartPlannerDb.Entities;

namespace SmartPlanner.Models
{
    public class GoalViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public int TotalProgress { get; set; }
        public int CurrentProgress { get; set; }
    }
}
