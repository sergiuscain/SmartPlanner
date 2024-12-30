using SmartPlannerDb.Entities;

namespace SmartPlannerDb
{
    public interface IProjectsStorage
    {
        Task AddAsync(Project project);
        Task DeleteAsync(Guid id);
        Task<List<Project>> GetAllAsync(string userId);
        Task<Project> GetAsync(Guid projectId);
    }
}