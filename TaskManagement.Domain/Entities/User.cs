using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities;

public class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(200)]
    public string Email { get; set; } = string.Empty;

    public ICollection<Project> Projects { get; set; } = new List<Project>();

    public ICollection<TaskItem> AssignedTasks { get; set; } = new List<TaskItem>();

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}