﻿using SmartPlannerDb.Model;

namespace SmartPlannerDb;

public interface INotesStorage
{
    Task<Note> AddAsync(Note note);
    Task<bool> DeleteAsync(Guid id);
    Task<List<Note>> GetAllAsync(string userId);
    Task<List<Note>> GetAllTestMethodAsync();
    Task<Note> GetByIdAsync(Guid id);
    Task UpdateAsync(Note note);
}