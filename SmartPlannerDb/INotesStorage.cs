using SmartPlannerDb.Model;

namespace SmartPlanner.Services
{
    public interface INotesStorage
    {
        Task<Note> AddAsync(Note note);
        Task<bool> DeleteAsync(Guid id);
        Task<List<Note>> GetAllByUserIdAsync(Guid userId);
        Task<List<Note>> GetAllTestMethodAsync();
        Task<Note> GetByIdAsync(Guid id);
        Task UpdateAsync(Note note);
    }
}