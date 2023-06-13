namespace BusinessLogic.Entities;

public partial class Utilizador
{
    public Guid Id { get; set; }

    public string? Email { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Nome { get; set; }

    public string? Genero { get; set; }

    public DateOnly DataDeNascimento { get; set; }

    public string? CodigoPostal { get; set; }

    public string? Morada { get; set; }

    public string? TipoUtilizador { get; set; }

    public string? EstadoUtilizador { get; set; }

    public virtual ICollection<Projeto> Projetos { get; set; } = new List<Projeto>();
}
