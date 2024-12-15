using System;
using SmartPlanner.Models;

namespace SmartPlanner.TestData
{
    public static class DataForTesting
    {
        public static Guid UserId = Guid.Parse("22c98a74-2913-4284-8b9c-b3e528838ba1");
        public static List<NoteDto> Notes { get; } = new List<NoteDto>();
        static DataForTesting()
        {
            for (var i = 0; i < 10; i++)
            {
                Notes.Add(new NoteDto
                {
                    Id = new Guid(),
                    Title = $"Title {i}",
                    Description = $"Description {i}",
                    UserId = UserId
                });
            }
        }
    }
}