using Microsoft.EntityFrameworkCore;
using Proyecto_DSWI_API_GP3.Data.IRepository;
using Proyecto_DSWI_API_GP3.Models;

namespace Proyecto_DSWI_API_GP3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Zonas> Zonas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Usuarios)
                .WithMany(u => u.Clientes)
                .HasForeignKey(c => c.IdUsuario);

            base.OnModelCreating(modelBuilder);
        }
    }
}
