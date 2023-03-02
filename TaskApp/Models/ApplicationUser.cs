using System.ComponentModel.DataAnnotations; 

namespace TaskApp.Models;

public class ApplicationUser 
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The username is required")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "The password is required")]
    public string? Password { get; set; }
}

