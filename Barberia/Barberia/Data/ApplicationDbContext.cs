using Library;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Barberia.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Barbero> Barbero { get; set; }
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<Peladas> Peladas { get; set; }
    public DbSet<Cobrar> Cobrar { get; set; }
    public DbSet<Ventas> Venta { get; set; }
    public DbSet<Compra> Compra { get; set; }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<Cuadre> Cuadre { get; set; }
}
