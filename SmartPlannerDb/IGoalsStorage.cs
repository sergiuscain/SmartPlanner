using SmartPlannerDb.Entities;

namespace SmartPlannerDb
{
    public interface IGoalsStorage
    {
        Task AddAsync(Goal goal);
        Task AddPointsAsync(Guid goalId, int point);
        Task DeleteAsync(Guid id);
        Task EditAsync(Goal goal);
        Task<List<Goal>> GetAllAsync(string userId);
        Task<Goal> GetByIdAsync(Guid id);
    }
}