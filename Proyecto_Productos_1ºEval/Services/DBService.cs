using System.Threading.Tasks;
using Avalonia.Collections;
using Microsoft.EntityFrameworkCore;
using Proyecto_Productos_1ºEval.Data;
using Proyecto_Productos_1ºEval.Models;

namespace RepasoApp.Services;

public class DBService
{
    public async Task<AvaloniaList<Usuario>> ObtenerUsuarios()
    {
        await using var db = new AppDBContext();
        await db.Database.EnsureCreatedAsync();
        var lista = await db.Usuarios.ToListAsync();
        return new AvaloniaList<Usuario>(lista);

    }
    
    public async Task<AvaloniaList<Lego>> ObtenerLegos()
    {
        await using var db = new AppDBLego();
        await db.Database.EnsureCreatedAsync();
        var lista = await db.Legos.ToListAsync();
        return new AvaloniaList<Lego>(lista);

    }
}