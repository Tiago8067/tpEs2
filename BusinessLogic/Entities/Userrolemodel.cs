using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Entities;

public partial class Userrolemodel
{
    [Required]
    public string? Roleid { get; set; }
    
    [Required]
    public string? Rolename { get; set; }
    
    [Required]
    public string? Userid { get; set; }
    
    [Required]
    public string? Username { get; set; }
}
