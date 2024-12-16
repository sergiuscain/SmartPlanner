using SmartPlanner.Data.Entities;
using SmartPlanner.Models;

namespace SmartPlanner.Helpers
{
    public static class MappingProfile
    {
        public static NoteViewModel ToViewModel(this Note note)
        {
            return new NoteViewModel
            {
                Id = note.Id,
                Description = note.Description,
                Title = note.Title,
                UserId = note.UserId,
            };
        }
        public static List<NoteViewModel> ToViewModel(this List<Note> notes)
        {
            return notes.Select(n => n.ToViewModel()).ToList();
        }
        public static Note ToDbModel(this NoteViewModel note)
        {
            return new Note
            {
                Id = note.Id,
                Description = note.Description,
                Title = note.Title,
                UserId = note.UserId,
            };
        }
        public static List<Note> ToDbModel(this List<NoteViewModel> notes)
        {
            return notes.Select(n => n.ToDbModel()).ToList();
        }
    }
}
