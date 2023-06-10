using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Tarefa
{
    public Guid Id { get; set; }

    public string CurtaDescricao { get; set; } = null!;

    public DateOnly DataHoraInicio { get; set; }

    public DateOnly? DataHoraFim { get; set; }

    public string EstadoTarefa { get; set; } = null!;

    public Guid? ProjetoId { get; set; }

    public virtual Projeto? Projeto { get; set; }
}
