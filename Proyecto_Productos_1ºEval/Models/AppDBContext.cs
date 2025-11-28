using Microsoft.EntityFrameworkCore;
using Proyecto_Productos_1ºEval.Models;

namespace Proyecto_Productos_1ºEval.Data;

public class AppDBContext: DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Lego>  Legos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=usuariosProyecto.db");
    }
    
    
}