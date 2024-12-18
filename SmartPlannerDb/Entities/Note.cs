namespace SmartPlannerDb.Model
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsSucessisCompleted { get; set; }
    }
}
