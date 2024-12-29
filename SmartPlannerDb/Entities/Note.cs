namespace SmartPlannerDb.Entities
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

        // Связь с проектом (необязательное свойство)
        public Guid? ProjectId { get; set; } // Nullable Guid
    }
}
