using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Product
{
    public int? Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Imgurl { get; set; }

    public decimal? Price { get; set; }
}
