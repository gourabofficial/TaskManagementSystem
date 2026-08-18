using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;

    public ProjectService(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProjectDto> CreateAsync(CreateProjectDto dto)
    {
        var project = new Project
        {
            Name = dto.Name,
            Description = dto.Description,
            OwnerId = dto.OwnerId
        };

        await _repository.AddAsync(project);
        await _repository.SaveChangesAsync();

        return new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            OwnerId = project.OwnerId
        };
    }

    public async Task<ProjectDto?> GetByIdAsync(int id)
    {
        var project = await _repository.GetByIdAsync(id);

        if (project == null)
            return null;

        return new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            OwnerId = project.OwnerId
        };
    }

    public async Task<ProjectDto?> UpdateAsync(int id, UpdateProjectDto dto)
    {
        var project = await _repository.GetByIdAsync(id);

        if (project == null)
            return null;

        project.Name = dto.Name;
        project.Description = dto.Description;
        project.OwnerId = dto.OwnerId;

        await _repository.UpdateAsync(project);
        await _repository.SaveChangesAsync();

        return new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            OwnerId = project.OwnerId
        };
    }

    public async Task<IEnumerable<ProjectDto>> GetAllAsync(FilterDto filterDto)
    {
        var projects = await _repository.GetAllAsync();

        // Apply filtering if searchTerm is provided
        if (!string.IsNullOrWhiteSpace(filterDto.SearchTerm))
        {
            projects = projects
                .Where(p => p.Name.Contains(filterDto.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                           p.Description.Contains(filterDto.SearchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Apply pagination
        var paginatedProjects = projects
            .Skip((filterDto.PageNumber - 1) * filterDto.PageSize)
            .Take(filterDto.PageSize)
            .ToList();

        return paginatedProjects.Select(p => new ProjectDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            OwnerId = p.OwnerId
        }).ToList();
    }
}
