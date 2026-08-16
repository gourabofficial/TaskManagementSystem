using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities;

public class Comment
{
    public int Id { get; set; }

    [Required]
    [MaxLength(2000)]
    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public int TaskItemId { get; set; }

    public TaskItem TaskItem { get; set; } = null!;

    [Required]
    public int UserId { get; set; }

    public User User { get; set; } = null!;
}