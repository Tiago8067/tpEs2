using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Registermodel
{
    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Confirmpassword { get; set; }
}
