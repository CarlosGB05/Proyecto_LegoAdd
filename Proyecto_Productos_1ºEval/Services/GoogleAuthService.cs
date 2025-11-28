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

public partial class GoogleAuthService: ViewModelBase
{
    public async Task<Usuario> LoginAsync(Usuario user)
    {
        using (var ddbb = new AppDBContext()) ddbb.Database.EnsureCreated();
        
        var client = await CreateClient();

        if (!string.IsNullOrEmpty(user.RefreshToken))
        {
            var refreshResult = await client.RefreshTokenAsync(user.RefreshToken);
            if (!refreshResult.IsError)
            {
                Console.WriteLine("Sesion restaurada");
                
                return user;
            }
            Console.WriteLine("No se pudo comprobar el token");
        }

        var result = await client.LoginAsync();
        if (result.IsError)
        {
            Console.WriteLine("Error al registrar usuario");
            return null;
        }

        var googlesub = result.User.FindFirst("sub")?.Value;
        var email = result.User.FindFirst("email")?.Value;
        var imagen = result.User.FindFirst("picture")?.Value;
        var nombre = result.User.FindFirst("name")?.Value;
        Console.WriteLine(googlesub+" "+email+" "+imagen+" "+nombre);

        var db = new AppDBContext();
        var usuario = db.Usuarios.FirstOrDefault(u => u.GoogleSub == googlesub);
        if (usuario == null)
        {
            usuario = new Usuario()
            {
                GoogleSub = googlesub,
                Email = email,
                Nombre = nombre,
                Imagen = imagen,
                RefreshToken = result.RefreshToken,
            };
            db.Usuarios.Add(usuario);
            await db.SaveChangesAsync();
            Console.WriteLine("Usuario registrado");
        }
        else
        {
            Console.WriteLine("Usuario ya registrado");
        }
        db.Dispose();
        return usuario;
    }

    public async Task<OidcClient> CreateClient()
    {
        using var http = new HttpClient();
        var keySet = await http.GetStringAsync("https://www.googleapis.com/oauth2/v3/certs");
        var jwks = new JsonWebKeySet(keySet);

        var options = new OidcClientOptions
        {
            Authority = "https://accounts.google.com",
            ClientId = "408792705593-feisvnlqfrh6rfpqvu0j4t50gtjc5jj7.apps.googleusercontent.com",
            ClientSecret = "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",
            Scope = "openid profile email",
            RedirectUri = "http://127.0.0.1:7890/",
            Browser = new SystemBrowser(7890),
            ProviderInformation = new ProviderInformation
            {
                AuthorizeEndpoint = "https://accounts.google.com/o/oauth2/v2/auth",
                TokenEndpoint = "https://oauth2.googleapis.com/token",
                UserInfoEndpoint = "https://openidconnect.googleapis.com/v1/userinfo",
                IssuerName = "https://accounts.google.com",
                KeySet = jwks
            }
        };

        return new OidcClient(options);
    }
}

