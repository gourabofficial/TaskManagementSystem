using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.DTOs;

public class UpdateProjectDto
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public int OwnerId { get; set; }
}
