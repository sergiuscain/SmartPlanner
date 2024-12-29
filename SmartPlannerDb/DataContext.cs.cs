using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using SmartPlannerDb.Entities;

namespace SmartPlannerDb
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Note>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<TaskModel>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Goal>()
                .HasOne(g => g.User)
                .WithMany(u => u.Goals)
                .HasForeignKey(g => g.UserId);

            modelBuilder.Entity<SubTask>()
                .HasOne(st => st.Task)
                .WithMany(t => t.SubTasks)
                .HasForeignKey(st => st.TaskId);

            modelBuilder.Entity<Project>()
            .HasOne(p => p.User)
            .WithMany(u => u.Projects) // Укажите, если у пользователя есть коллекция проектов
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            // Настройка отношений между проектом и задачами, заметками и целями
            modelBuilder.Entity<TaskModel>()
                .HasOne<Project>()
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Note>()
                .HasOne<Project>()
                .WithMany(p => p.Notes)
                .HasForeignKey(n => n.ProjectId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Goal>()
                .HasOne<Project>()
                .WithMany(p => p.Goals)
                .HasForeignKey(g => g.ProjectId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
        
    }
}
