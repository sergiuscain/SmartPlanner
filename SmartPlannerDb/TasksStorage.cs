using Microsoft.EntityFrameworkCore;
using SmartPlannerDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlannerDb
{
    public class TasksStorage : ITasksStorage
    {
        private readonly DataContext _context;
        public TasksStorage(DataContext context)
        {
            _context = context;
        }
        public async Task<List<TaskModel>> GetAllAsync(string userId)
        {
            return await _context.Tasks.Where(t => t.UserId == userId).ToListAsync();
        }
        public async Task<TaskModel> GetByIdAsync(Guid id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.TaskModelId == id);
        }
        public async Task AddAsync(TaskModel task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(TaskModel task)
        {
            _context.Update(task);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskModelId == id);
            if (task != null)
            {
                _context.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
