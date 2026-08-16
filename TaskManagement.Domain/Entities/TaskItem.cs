using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities;

public class TaskItem
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public int ProjectId { get; set; }

    public Project Project { get; set; } = null!;

    [Required]
    public int AssignedUserId { get; set; }

    public User AssignedUser { get; set; } = null!;

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}