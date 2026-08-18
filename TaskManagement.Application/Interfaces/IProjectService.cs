using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Interfaces;

public interface IProjectService
{
    Task<ProjectDto> CreateAsync(CreateProjectDto dto);
    Task<ProjectDto?> GetByIdAsync(int id);
    Task<ProjectDto?> UpdateAsync(int id, UpdateProjectDto dto);
    Task<IEnumerable<ProjectDto>> GetAllAsync(FilterDto filterDto);
}