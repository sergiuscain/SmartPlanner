using Microsoft.EntityFrameworkCore;
using SmartPlannerDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlannerDb
{
    public class ProjectsStorage : IProjectsStorage
    {
        private readonly DataContext _context;
        public ProjectsStorage(DataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var project = await _context.Projects.Include(p => p.Tasks).Include(p => p.Goals).Include(p => p.Notes).FirstOrDefaultAsync(p => p.ProjectId == id);
            _context.Goals.RemoveRange(project.Goals);
            _context.Tasks.RemoveRange(project.Tasks);
            _context.Notes.RemoveRange(project.Notes);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Project>> GetAllAsync(string userId)
        {
            var projects = await _context.Projects.Where(p => p.UserId == userId).ToListAsync();
            return projects;
        }

        public async Task<Project> GetAsync(Guid projectId)
        {
            var project = await _context.Projects.Include(p => p.Tasks).ThenInclude(t => t.SubTasks).Include(p => p.Notes).Include(p => p.Goals).FirstOrDefaultAsync(p => p.ProjectId == projectId);
            return project;
        }
    }
}
