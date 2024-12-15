using Microsoft.EntityFrameworkCore;
using SmartPlanner.Data;
using SmartPlanner.Data.Entities;

namespace SmartPlanner.Services
{
    public class NotesStorage : INotesStorage
    {
        private readonly DataContext _context;
        public NotesStorage(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Note>> GetAllByUserIdAsync(Guid userId)
        {
            var notes = await _context.Notes.Where(n => n.UserId == userId).ToListAsync();
            if (notes != null)
                return notes;
            return null;
        }
        public async Task<Note> GetByIdAsync(Guid id)
        {
            return await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);
        }
        public async Task<Note> AddAsync(Note note)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
            return note;
        }
        public async Task UpdateAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}