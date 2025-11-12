using CommunityToolkit.Mvvm.Input;
using Proyecto_Productos_1ºEval.Services;

namespace Proyecto_Productos_1ºEval.ViewModels;

public partial class MainCreateProductModel : ViewModelBase
{
    private NavigationService navegacionCreate;

    public MainCreateProductModel(NavigationService navegacion)
    {
        navegacionCreate = navegacion;
    }
    
    [RelayCommand]
    public void NavegarHome()
    {
        navegacionCreate.NavigateTo("google");
    }
    
    [RelayCommand]
    public void NavegarTienda()
    {
        navegacionCreate.NavigateTo("bienvenida");
    }
}