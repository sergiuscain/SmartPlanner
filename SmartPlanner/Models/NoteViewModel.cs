namespace SmartPlanner.Models
{
    public class NoteViewModel
    {
        public Guid NoteId { get; set; }
        public Guid? ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
