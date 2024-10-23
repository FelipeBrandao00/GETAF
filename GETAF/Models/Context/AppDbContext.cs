using GETAF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace GETAF.Models.Context;
public class AppDbContext : DbContext {
    public AppDbContext() { }
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Dificuldade> Dificuldades { get; set; }
    public DbSet<Materia> Materias { get; set; }
    public DbSet<Grupo> Grupos { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<GrupoUsuario> GrupoUsuarios { get; set; }
    public DbSet<Quiz> Quiz { get; set; }
    public DbSet<QuizUsuario> QuizUsuarios { get; set; }
    public DbSet<Alternativa> Alternativas { get; set; }

    public DbSet<Ranking> Ranking { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-HDNU4UN;Initial Catalog=GETAF;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=GETAF;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Ranking>()
        .HasKey(rk => new { rk.GrupoId, rk.UsuarioId });

        modelBuilder.Entity<GrupoUsuario>()
        .HasKey(gu => new { gu.GrupoId, gu.UsuarioId });

        modelBuilder.Entity<QuizUsuario>()
       .HasKey(gu => new { gu.QuizId, gu.UsuarioId });

        modelBuilder.Entity<QuizUsuario>()
            .HasOne(q => q.Quiz)
            .WithMany(g => g.QuizUsuarios)
            .HasForeignKey(gu => gu.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<QuizUsuario>()
           .HasOne(q => q.Usuario)
           .WithMany(g => g.QuizUsuarios)
           .HasForeignKey(gu => gu.QuizId)
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<GrupoUsuario>()
            .HasOne(gu => gu.Grupo)
            .WithMany(g => g.GrupoUsuarios)
            .HasForeignKey(gu => gu.GrupoId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<GrupoUsuario>()
            .HasOne(gu => gu.Usuario)
            .WithMany(u => u.GrupoUsuarios)
            .HasForeignKey(gu => gu.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Tarefa>()
       .HasOne(t => t.Usuario)
       .WithMany(u => u.Tarefas)
       .HasForeignKey(t => t.UsuarioId)
       .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Quiz>()
      .HasOne(t => t.Usuario)
      .WithMany(u => u.Quiz)
      .HasForeignKey(t => t.UsuarioId)
      .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Ranking>()
            .HasOne(r => r.Usuario)
            .WithMany(u => u.Ranking)
            .HasForeignKey(r => r.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Ranking>()
            .HasOne(r => r.Grupo)
            .WithMany(g => g.Ranking)
            .HasForeignKey(r => r.GrupoId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
