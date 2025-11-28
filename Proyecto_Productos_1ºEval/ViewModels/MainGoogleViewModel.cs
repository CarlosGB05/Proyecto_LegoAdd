using System.Threading.Tasks;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto_Productos_1ºEval.Models;
using Proyecto_Productos_1ºEval.Services;
using RepasoApp.Services;

namespace Proyecto_Productos_1ºEval.ViewModels;

public partial class MainGoogleViewModel : ViewModelBase
{
    private NavigationService navegacionGoogle;
    [ObservableProperty] private AvaloniaList<Usuario> listaUsuarios = new();
    [ObservableProperty] private string imagenURL;

    public MainGoogleViewModel(NavigationService navegacion)
    {
        navegacionGoogle = navegacion;
        ObtenerUsuariosAsync();
    }

    public MainGoogleViewModel()
    {
        
    }

    [RelayCommand]
    public void NavegarHome()
    {
        navegacionGoogle.NavigateTo("google");
    }
    
    [RelayCommand]
    public void NavegarTienda()
    {
        navegacionGoogle.NavigateTo("bienvenida");
    }
    
    [RelayCommand]
    public async void ObtenerUsuariosAsync()
    {
        ListaUsuarios = await new DBService().ObtenerUsuarios();
        
    }
    
    [RelayCommand]
    public async Task RegistroUsuarioAsync()
    {
        var authservice = new GoogleAuthService();
        Usuario usuario = await authservice.LoginAsync(new Usuario());
        ImagenURL = usuario.Imagen;
    }
    
    [RelayCommand]
    public async Task LoginUsuarioAsync(Usuario user)
    {
        var authservice = new GoogleAuthService();
        if (await authservice.LoginAsync(user) != null)
        {
            NavegarTienda();
        }
    }
    
}