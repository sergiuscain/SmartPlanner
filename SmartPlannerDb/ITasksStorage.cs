using SmartPlannerDb.Entities;

namespace SmartPlannerDb
{
    public interface ITasksStorage
    {
        Task AddAsync(TaskModel task);
        Task DeleteAsync(Guid id);
        Task<List<TaskModel>> GetAllAsync(string userId);
        Task<TaskModel> GetByIdAsync(Guid id);
        Task UpdateAsync(TaskModel task);
    }
}