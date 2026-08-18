using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces;

public interface IProjectRepository
{
    Task<Project> AddAsync(Project project);

    Task<Project?> GetByIdAsync(int id);

    Task<List<Project>> GetAllAsync();

    Task<Project?> UpdateAsync(Project project);

    Task SaveChangesAsync();
}