using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Interfaces;

public interface IProjectService
{
    Task<ProjectDto> CreateAsync(CreateProjectDto dto);
}