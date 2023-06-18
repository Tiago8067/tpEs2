﻿using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Entities;

public partial class Loginmodel
{
    [Required, EmailAddress]
    public string? Email { get; set; }

    [Required, DataType(DataType.Password)]
    public string? Password { get; set; }
}
