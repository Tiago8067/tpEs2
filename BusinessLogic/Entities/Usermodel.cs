using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Entities;

/*public partial class Usermodel
{
    public Guid Id { get; set; }

    public string? Email { get; set; }

    public byte[]? Passhash { get; set; }

    public byte[]? Passsalt { get; set; }

    public DateTime? Datacriacao { get; set; }
}*/

public class Usermodel
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public byte[] Passhash { get; set; }
    public byte[] Passsalt { get; set; }
    
    [Column(TypeName = "timestamp with time zone")]
    public DateTime Datacriacao { get; set; } = DateTime.UtcNow;
}
