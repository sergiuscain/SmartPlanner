
namespace SmartPlanner.Models
{
    public class SubTaskViewModel
    {
        public Guid SubTaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid TaskId { get; set; }
        public TaskViewModel Task { get; set; }
    }
}
