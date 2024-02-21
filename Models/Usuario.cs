using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TeatroApi.Models;


public class Usuario
{
    [Key]
    public int IdUser { get; set; }
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public UserRole Rol { get; set; }
    public enum UserRole
    {
        Admin,
        StandardUser
    }
}