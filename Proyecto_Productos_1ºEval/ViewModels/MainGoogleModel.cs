using CommunityToolkit.Mvvm.Input;
using Proyecto_Productos_1ºEval.Services;

namespace Proyecto_Productos_1ºEval.ViewModels;

public partial class MainGoogleModel : ViewModelBase
{
    private NavigationService navegacionGoogle;

    public MainGoogleModel(NavigationService navegacion)
    {
        navegacionGoogle = navegacion;
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
}