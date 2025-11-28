using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Duende.IdentityModel.Jwk;
using Duende.IdentityModel.OidcClient;
using Proyecto_Productos_1ºEval.Models;
using Proyecto_Productos_1ºEval.Data;
using Proyecto_Productos_1ºEval.Utils;
using Proyecto_Productos_1ºEval.ViewModels;

namespace Proyecto_Productos_1ºEval.Services;

public partial class LegoAuthService: ViewModelBase
{
    public async Task<Lego> LoginAsync(Lego user)
    {
        using (var ddbb = new AppDBLego()) ddbb.Database.EnsureCreated();
        
        var db = new AppDBLego();
        if (user != null)
        {
            var legoCreado = new Lego()
            {
                NumSet = user.NumSet,
                Nombre = user.Nombre,
                Cantidad = user.Cantidad,
                Categoria = user.Categoria,
                Fecha = user.Fecha,
                Disponible = user.Disponible
            };
            db.Legos.Add(legoCreado);
            db.SaveChanges();
            Console.WriteLine("Lego registrado");
        }
        else
        {
            Console.WriteLine("ERROR");
        }
        db.Dispose();
        return user;
    }
    
}