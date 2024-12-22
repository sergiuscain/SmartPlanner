using SmartPlanner.Models;
using SmartPlannerDb.Entities;

namespace SmartPlanner.TestData
{
    public static class DataForTesting
    {
        public static List<NoteViewModel> Notes { get; } = new List<NoteViewModel>();
        public static Note TestNote { get; } = new Note 
        {
            NoteId = new Guid(),
            Title = $"Title for test",
            Description = $"Description for test",
            //UserId = UserId
        };
        static DataForTesting()
        {
            for (var i = 0; i < 10; i++)
            {
                Notes.Add(new NoteViewModel
                {
                    NoteId = new Guid(),
                    Title = $"Title {i}",
                    Description = $"Description {i}",
                });
            }
        }
    }
}