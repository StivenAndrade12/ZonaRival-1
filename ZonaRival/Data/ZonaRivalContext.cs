using Microsoft.EntityFrameworkCore;
using ZonaRival.Models;

namespace ZonaRival.Data
{
    public class ZonaRivalContext : DbContext
    {
        public ZonaRivalContext(DbContextOptions<ZonaRivalContext> options) : base(options){}

        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Usuario> Usuarios {  get; set; }
        public DbSet<Cancha> Canchas {  get; set; }

        //tablas relacionales
        public DbSet<EquipoCancha> EquiposCanchas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definiendo la clave primaria
            modelBuilder.Entity<EquipoCancha>()
                .HasKey(ec => new { ec.EquipoId, ec.CanchaId });

            // Relacionando EquipoCancha con Equipo y con Cancha
            modelBuilder.Entity<EquipoCancha>()
                .HasOne(ec => ec.Equipo)
                .WithMany(e => e.EquiposCanchas)
                .HasForeignKey(ec => ec.EquipoId);

            modelBuilder.Entity<EquipoCancha>()
                .HasOne(ec => ec.Cancha)
                .WithMany(c => c.EquiposCanchas)
                .HasForeignKey(ec => ec.CanchaId);

            //relacion de Usuario y Equipo
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Equipo)
                .WithMany(e => e.Usuarios)
                .HasForeignKey(u => u.IdEquipo);
        }
    }
}
