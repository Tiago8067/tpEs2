using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Utilizadore
{
    public Guid Id { get; set; }

    public string? Email { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Projeto> Projetos { get; set; } = new List<Projeto>();
}
