using System;
using SmartPlanner.Data.Entities;
using SmartPlanner.Models;

namespace SmartPlanner.TestData
{
    public static class DataForTesting
    {
        public static Guid UserId = Guid.Parse("22c98a74-2913-4284-8b9c-b3e528838ba1");
        public static List<NoteViewModel> Notes { get; } = new List<NoteViewModel>();
        public static Note TestNote { get; } = new Note 
        {
            Id = new Guid(),
            Title = $"Title for test",
            Description = $"Description for test",
            UserId = UserId
        };
        static DataForTesting()
        {
            for (var i = 0; i < 10; i++)
            {
                Notes.Add(new NoteViewModel
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