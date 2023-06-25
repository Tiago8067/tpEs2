using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Entities;

/*
public partial class Userchangepassword
{
    public string? Pass { get; set; }

    public string? Confirmpass { get; set; }
}
*/

public class Userchangepassword
{
    [Required, StringLength(100, MinimumLength = 4)]
    public string Pass { get; set; } = string.Empty;
        
    [Compare("Pass", ErrorMessage = "As pass não coincidem.")]
    public string Confirmpass { get; set; } = string.Empty;
}
