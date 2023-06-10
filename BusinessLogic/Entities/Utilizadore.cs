using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Utilizadore
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public DateOnly DataDeNascimento { get; set; }

    public string CodigoPostal { get; set; } = null!;

    public string Morada { get; set; } = null!;

    public string TipoUtilizador { get; set; } = null!;

    public string EstadoUtilizador { get; set; } = null!;

    public virtual ICollection<Projeto> Projetos { get; set; } = new List<Projeto>();
}
