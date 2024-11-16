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
    public DbSet<PerguntaUsuario> RespostaUsuario { get; set; }
    public DbSet<Pergunta> Perguntas { get; set; } 
    public DbSet<Alternativa> Alternativas { get; set; }

    public DbSet<Ranking> Ranking { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=GETAF;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=GETAF;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Ranking>()
        .HasKey(rk => new { rk.GrupoId, rk.UsuarioId });

        modelBuilder.Entity<GrupoUsuario>()
        .HasKey(gu => new { gu.GrupoId, gu.UsuarioId });

        modelBuilder.Entity<PerguntaUsuario>()
       .HasKey(gu => new { gu.PerguntaId, gu.UsuarioId });

        modelBuilder.Entity<Quiz>()
            .HasKey(qz => qz.Id);
        modelBuilder.Entity<Pergunta>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Alternativa>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<Quiz>()
            .HasOne(q => q.Grupo)
            .WithMany(p => p.Quizzes)
            .HasForeignKey(g => g.GrupoId);

        modelBuilder.Entity<Pergunta>()
            .HasOne(p => p.Quiz)
            .WithMany(p => p.Perguntas)
            .HasForeignKey(q => q.QuizId);

        modelBuilder.Entity<Alternativa>()
            .HasOne(a => a.Pergunta)
            .WithMany(a => a.Alternativas)
            .HasForeignKey(p => p.PerguntaId);

        modelBuilder.Entity<PerguntaUsuario>()
            .HasOne(q => q.Pergunta)
            .WithMany(g => g.RespostaUsuarios)
            .HasForeignKey(gu => gu.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PerguntaUsuario>()
           .HasOne(q => q.Usuario)
           .WithMany(g => g.RespostaUsuarios)
           .HasForeignKey(gu => gu.UsuarioId)
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
