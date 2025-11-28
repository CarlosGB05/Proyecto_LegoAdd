using Microsoft.EntityFrameworkCore;

namespace Proyecto_Productos_1ºEval.Models;

public class AppDBLego:DbContext
{
    public DbSet<Lego> Legos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=legosProyecto.db");
    }
}