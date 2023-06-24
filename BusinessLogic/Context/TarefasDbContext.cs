using System;
using System.Collections.Generic;
using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Context;

public partial class TarefasDbContext : DbContext
{
    public TarefasDbContext()
    {
    }

    public TarefasDbContext(DbContextOptions<TarefasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Projeto> Projetos { get; set; }

    public virtual DbSet<Tarefa> Tarefas { get; set; }

    public virtual DbSet<Usermodel> Usermodels { get; set; }

    public virtual DbSet<Userregisto> Userregistos { get; set; }

    public virtual DbSet<Utilizadore> Utilizadores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=es2;Username=es2;Password=es2;SearchPath=public;Port=15432");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("postgis")
            .HasPostgresExtension("uuid-ossp")
            .HasPostgresExtension("topology", "postgis_topology");

        modelBuilder.Entity<Product>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("product");

            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Imgurl)
                .HasMaxLength(250)
                .HasColumnName("imgurl");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Projeto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("projetos_pkey");

            entity.ToTable("projetos");

            entity.HasIndex(e => e.Nome, "projetos_nome_key").IsUnique();

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

        modelBuilder.Entity<Usermodel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usermodel_pkey");

            entity.ToTable("usermodel");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Datacriacao).HasColumnName("datacriacao");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("email");
            entity.Property(e => e.Passhash).HasColumnName("passhash");
            entity.Property(e => e.Passsalt).HasColumnName("passsalt");
        });

        modelBuilder.Entity<Userregisto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("userregisto");

            entity.Property(e => e.ConfirmPass)
                .HasMaxLength(250)
                .HasColumnName("confirm_pass");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("email");
            entity.Property(e => e.Pass)
                .HasMaxLength(250)
                .HasColumnName("pass");
        });

        modelBuilder.Entity<Utilizadore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("utilizadores_pkey");

            entity.ToTable("utilizadores");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
