using CommunityToolkit.Mvvm.Input;
using Proyecto_Productos_1ºEval.Services;

namespace Proyecto_Productos_1ºEval.ViewModels;

public partial class MainListProductModel : ViewModelBase
{
    private NavigationService navegacionList;

    public MainListProductModel(NavigationService navegacion)
    {
        navegacionList = navegacion;
    }
    
    [RelayCommand]
    public void NavegarHome()
    {
        navegacionList.NavigateTo("google");
    }
    
    [RelayCommand]
    public void NavegarTienda()
    {
        navegacionList.NavigateTo("bienvenida");
    }
}