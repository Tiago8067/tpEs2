using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Entities;

public partial class Product
{
    public int? Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Imgurl { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Price { get; set; }
}
