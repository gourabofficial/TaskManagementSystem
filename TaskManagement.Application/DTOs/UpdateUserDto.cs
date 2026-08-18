using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.DTOs;

public class UpdateUserDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(200)]
    public string Email { get; set; } = string.Empty;
}
