using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces;

public interface IUserRepository
{
    Task<User> AddAsync(User user);

    Task<User?> GetByIdAsync(int id);

    Task<List<User>> GetAllAsync();

    Task<User?> UpdateAsync(User user);

    Task SaveChangesAsync();
}