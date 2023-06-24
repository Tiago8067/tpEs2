using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Entities;

/*public partial class Userlogin
{
    public string? Email { get; set; }

    public string? Pass { get; set; }
}*/

public class Userlogin
{
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Pass { get; set; } = string.Empty;
}
