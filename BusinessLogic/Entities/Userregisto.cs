using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Entities;

/*public partial class Userregisto
{
    public string? Email { get; set; }

    public string? Pass { get; set; }

    public string? ConfirmPass { get; set; }
}*/

public class Userregisto
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required, StringLength(100, MinimumLength = 4)]
    public string Pass { get; set; } = string.Empty;
    
    [Compare("Pass", ErrorMessage = "The passwords do not match.")]
    public string ConfirmPass { get; set; } = string.Empty;
}
