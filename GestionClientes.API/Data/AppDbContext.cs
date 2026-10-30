using GestionClientes.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionClientes.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id_cliente);
            entity.Property(e => e.Id_cliente).ValueGeneratedOnAdd();
            entity.Property(e => e.CUI).HasMaxLength(20).IsRequired();
            entity.Property(e => e.NIT).HasMaxLength(20).IsRequired();
            entity.Property(e => e.Nombres).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Apellidos).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Direccion).HasMaxLength(200).IsRequired();
            entity.Property(e => e.Telefono).HasMaxLength(20).IsRequired();
            entity.Property(e => e.Fecha_Nacimiento).HasColumnType("date");
        });
    }
}
