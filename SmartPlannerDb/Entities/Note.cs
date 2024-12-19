using SmartPlannerDb.Entities;

namespace SmartPlannerDb.Model
{
    public class Note
    {
        public Guid NoteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsSucessisCompleted { get; set; }
        public string UserId { get; set; }


        //Навигационные свойства:
        public User User { get; set; }
    }
}
