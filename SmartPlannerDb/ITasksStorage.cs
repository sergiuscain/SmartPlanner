using SmartPlannerDb.Entities;

namespace SmartPlannerDb
{
    public interface ITasksStorage
    {
        Task AddAsync(TaskModel task);
        Task DeleteAsync(Guid id);
        Task<List<TaskModel>> GetAllAsync(string userId);
        Task<List<TaskModel>> GetByStatusAsync(string userId, string status);
        Task EditStatusAsync(Guid taskId, string newStatus);
        Task<TaskModel> GetByIdAsync(Guid id);
        Task UpdateAsync(TaskModel task);
    }
}