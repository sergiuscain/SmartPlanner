using SmartPlannerDb.Entities;

namespace SmartPlannerDb
{
    public interface IGoalsStorage
    {
        Task AddAsync(Goal goal);
        Task AddPoints(Guid goalId, int point);
        Task Delete(Guid id);
        Task<List<Goal>> GetAllAsync(string userId);
        Task<Goal> GetById(Guid id);
    }
}