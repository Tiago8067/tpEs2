﻿using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Projeto
{
    public Guid Id { get; set; }

    public string? Nome { get; set; }

    public string? NomeCliente { get; set; }

    public double? PrecoPorHora { get; set; }

    public Guid? UtilizadorId { get; set; }

    public virtual ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();

    public virtual Utilizadore? Utilizador { get; set; }
}
