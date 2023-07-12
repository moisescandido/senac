
using Microsoft.EntityFrameworkCore;
using senac.Models;

namespace senac.Data
{
    public class ForumDbContext : DbContext
    {
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<PostagemModel> Postagem { get; set; }
        public DbSet<GosteiModel> Gostei { get; set; }
        public DbSet<CategoriaModel> Categoria { get; set; }
        public DbSet<ComentarioModel> Comentario { get; set; }
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostagemModel>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.IdUsuario)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PostagemModel>()
                .HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.IdCategoria)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GosteiModel>()
                .HasOne(g => g.Postagem)
                .WithMany()
                .HasForeignKey(g => g.IdPostagem)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GosteiModel>()
                .HasOne(g => g.Usuario)
                .WithMany()
                .HasForeignKey(g => g.IdUsuario)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ComentarioModel>()
                .HasOne(c => c.Postagem)
                .WithMany()
                .HasForeignKey(c => c.IdPostagem)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ComentarioModel>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.IdUsuario)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}