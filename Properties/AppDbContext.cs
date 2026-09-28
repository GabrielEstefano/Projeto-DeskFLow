using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projeto.Properties.Entity;

namespace Projeto.Properties
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasMany(c => c.Chamados).WithOne(ch => ch.Categoria).HasForeignKey(ch => ch.CategoriaId);base.OnModelCreating(modelBuilder);}
        public DbSet<Chamado> Chamados {get; set; }
        public DbSet<Categoria> categorias {get; set; }
    }
}