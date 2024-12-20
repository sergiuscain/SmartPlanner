﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmartPlannerDb.Entities;
using SmartPlannerDb.Model;

namespace SmartPlannerDb
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

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
        }
    }
}
