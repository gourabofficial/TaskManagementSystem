using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserDto> CreateAsync(CreateUserDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email
        };

        await _repository.AddAsync(user);
        await _repository.SaveChangesAsync();

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null)
            return null;

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }

    public async Task<UserDto?> UpdateAsync(int id, UpdateUserDto dto)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null)
            return null;

        user.Name = dto.Name;
        user.Email = dto.Email;

        await _repository.UpdateAsync(user);
        await _repository.SaveChangesAsync();

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync(FilterDto filterDto)
    {
        var users = await _repository.GetAllAsync();

        // Apply filtering if searchTerm is provided
        if (!string.IsNullOrWhiteSpace(filterDto.SearchTerm))
        {
            users = users
                .Where(u => u.Name.Contains(filterDto.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                           u.Email.Contains(filterDto.SearchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Apply pagination
        var paginatedUsers = users
            .Skip((filterDto.PageNumber - 1) * filterDto.PageSize)
            .Take(filterDto.PageSize)
            .ToList();

        return paginatedUsers.Select(u => new UserDto
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email
        }).ToList();
    }
}
