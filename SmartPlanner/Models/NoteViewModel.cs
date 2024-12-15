namespace SmartPlanner.Models
{
    public class NoteViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}
