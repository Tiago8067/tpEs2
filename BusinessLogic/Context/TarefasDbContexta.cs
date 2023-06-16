﻿using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Context;

public partial class TarefasDbContexta : DbContext
{
    public TarefasDbContexta()
    {
    }

    public TarefasDbContexta(DbContextOptions<TarefasDbContexta> options)
        : base(options)
    {
    }
    

    public virtual DbSet<Projeto> Projetos { get; set; }

    public virtual DbSet<Tarefa> Tarefas { get; set; }

    public virtual DbSet<Utilizador> Utilizadores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=es2;Username=es2;Password=es2;SearchPath=public;Port=15432");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("postgis")
            .HasPostgresExtension("uuid-ossp")
            .HasPostgresExtension("topology", "postgis_topology");

        modelBuilder.Entity<Projeto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("projetos_pkey");

            entity.ToTable("projetos");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .HasColumnName("nome");
            entity.Property(e => e.NomeCliente)
                .HasMaxLength(250)
                .HasColumnName("nome_cliente");
            entity.Property(e => e.PrecoPorHora).HasColumnName("preco_por_hora");
            entity.Property(e => e.UtilizadorId).HasColumnName("utilizador_id");

            entity.HasOne(d => d.Utilizador).WithMany(p => p.Projetos)
                .HasForeignKey(d => d.UtilizadorId)
                .HasConstraintName("projetos_utilizador_id_fkey");
        });

        modelBuilder.Entity<Tarefa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tarefas_pkey");

            entity.ToTable("tarefas");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CurtaDescricao)
                .HasMaxLength(250)
                .HasColumnName("curta_descricao");
            entity.Property(e => e.DataHoraFim).HasColumnName("data_hora_fim");
            entity.Property(e => e.DataHoraInicio).HasColumnName("data_hora_inicio");
            entity.Property(e => e.EstadoTarefa)
                .HasMaxLength(100)
                .HasColumnName("estado_tarefa");
            entity.Property(e => e.ProjetoId).HasColumnName("projeto_id");

            entity.HasOne(d => d.Projeto).WithMany(p => p.Tarefas)
                .HasForeignKey(d => d.ProjetoId)
                .HasConstraintName("tarefas_projeto_id_fkey");
        });

        modelBuilder.Entity<Utilizador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("utilizadores_pkey");

            entity.ToTable("utilizadores");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(100)
                .HasColumnName("codigo_postal");
            entity.Property(e => e.DataDeNascimento).HasColumnName("data_de_nascimento");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("email");
            entity.Property(e => e.EstadoUtilizador)
                .HasMaxLength(100)
                .HasColumnName("estado_utilizador");
            entity.Property(e => e.Genero)
                .HasMaxLength(250)
                .HasColumnName("genero");
            entity.Property(e => e.Morada)
                .HasMaxLength(100)
                .HasColumnName("morada");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .HasColumnName("nome");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.TipoUtilizador)
                .HasMaxLength(100)
                .HasColumnName("tipo_utilizador");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}