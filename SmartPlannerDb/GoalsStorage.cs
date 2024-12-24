using Microsoft.EntityFrameworkCore;
using SmartPlannerDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlannerDb
{
    public class GoalsStorage : IGoalsStorage
    {
        private readonly DataContext _context;
        public GoalsStorage(DataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Goal goal)
        {
            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            var goal = await _context.Goals.FirstOrDefaultAsync(x => x.Id == id);
            if (goal != null)
            {
                _context.Goals.Remove(goal);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Goal>> GetAllAsync(string userId)
        {
            var goals = _context.Goals.Where(x => x.UserId == userId);
            return await goals.ToListAsync();
        }
        public async Task<Goal> GetById(Guid id)
        {
            return await _context.Goals.FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task AddPoints(Guid goalId, int point)
        {
            var goal = await GetById(goalId);
            goal.CurrentProgress += point;
            await _context.SaveChangesAsync();
        }
    }
}
