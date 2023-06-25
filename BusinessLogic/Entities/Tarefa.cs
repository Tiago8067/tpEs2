using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Tarefa
{
    public Guid Id { get; set; }

    public string? CurtaDescricao { get; set; }

    public DateTime? DataHoraInicio { get; set; }

    public DateTime? DataHoraFim { get; set; }

    public string? EstadoTarefa { get; set; }

    public Guid? ProjetoId { get; set; }

    public virtual Projeto? Projeto { get; set; }
}
