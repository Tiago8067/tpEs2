using System;
using System.Collections.Generic;
using BusinessLogic.Entities;
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

    public virtual DbSet<Loginmodel> Loginmodels { get; set; }

    public virtual DbSet<Loginresult> Loginresults { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Projeto> Projetos { get; set; }

    public virtual DbSet<Registermodel> Registermodels { get; set; }

    public virtual DbSet<Registerresult> Registerresults { get; set; }

    public virtual DbSet<Rolemodel> Rolemodels { get; set; }

    public virtual DbSet<Tarefa> Tarefas { get; set; }

    public virtual DbSet<Usermodel> Usermodels { get; set; }

    public virtual DbSet<Userrolemodel> Userrolemodels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql(
            "Host=localhost;Database=es2;Username=es2;Password=es2;SearchPath=public;Port=15432");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("postgis")
            .HasPostgresExtension("uuid-ossp")
            .HasPostgresExtension("topology", "postgis_topology");

        modelBuilder.Entity<Loginmodel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("loginmodel");

            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Loginresult>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("loginresult");

            entity.Property(e => e.Error)
                .HasMaxLength(250)
                .HasColumnName("error");
            entity.Property(e => e.Successful).HasColumnName("successful");
            entity.Property(e => e.Token)
                .HasMaxLength(500)
                .HasColumnName("token");
        });

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

        /*modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Title = "The Hitchhiker's Guide to the Galaxy",
                Description =
                    "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science",
                Imgurl = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                Price = 9.99m
            }, new Product
            {
                Id = 2,
                Title = "Ready Player One",
                Description =
                    "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. ",
                Imgurl = "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",
                Price = 7.99m
            }, new Product
            {
                Id = 3,
                Title = "Nineteen Eighty-Four",
                Description =
                    "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel",
                Imgurl = "https://upload.wikimedia.org/wikipedia/commons/c/c3/1984first.jpg",
                Price = 6.99m
            }, new Product
            {
                Id = 4,
                Title = "The Matrix",
                Description = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis",
                Imgurl = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg",
                Price = 11.99m
            }, new Product
            {
                Id = 5,
                Title = "Back to the Future",
                Description = "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis.",
                Imgurl = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg",
                Price = 8.99m
            }
        );*/

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

        modelBuilder.Entity<Registermodel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("registermodel");

            entity.Property(e => e.Confirmpassword)
                .HasMaxLength(250)
                .HasColumnName("confirmpassword");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Registerresult>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("registerresult");

            entity.Property(e => e.Message)
                .HasMaxLength(250)
                .HasColumnName("message");
            entity.Property(e => e.Successful).HasColumnName("successful");
        });

        modelBuilder.Entity<Rolemodel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rolemodel");

            entity.Property(e => e.Id)
                .HasMaxLength(250)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
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
            entity
                .HasNoKey()
                .ToTable("usermodel");

            entity.Property(e => e.Id)
                .HasMaxLength(250)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Userrolemodel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("userrolemodel");

            entity.Property(e => e.Roleid)
                .HasMaxLength(250)
                .HasColumnName("roleid");
            entity.Property(e => e.Rolename)
                .HasMaxLength(250)
                .HasColumnName("rolename");
            entity.Property(e => e.Userid)
                .HasMaxLength(250)
                .HasColumnName("userid");
            entity.Property(e => e.Username)
                .HasMaxLength(250)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}