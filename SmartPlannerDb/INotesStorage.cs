using SmartPlannerDb.Entities;

namespace SmartPlannerDb;

public interface INotesStorage
{
    Task<Note> AddAsync(Note note);
    Task<bool> DeleteAsync(Guid id);
    Task<List<Note>> GetAllAsync(string userId);
    Task<List<Note>> GetAllTestMethodAsync();
    Task<Note> GetByIdAsync(Guid id);
    Task UpdateAsync(Note note);
    Task<List<Note>> GetByPageAsync(string userId, int pageSize, int page);
}