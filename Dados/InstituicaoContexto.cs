using Instituicao.Models;
using Microsoft.EntityFrameworkCore;

namespace Instituicao.Dados
{
    public class InstituicaoContexto : DbContext
    {
        public InstituicaoContexto(DbContextOptions<InstituicaoContexto> options) : base(options) { }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Curso> Curso { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Curso>().ToTable("Curso");
        }
    }
}