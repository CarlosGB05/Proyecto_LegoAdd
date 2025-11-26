using CommunityToolkit.Mvvm.Input;
using Proyecto_Productos_1ºEval.Services;

namespace Proyecto_Productos_1ºEval.ViewModels;

public partial class MainBienvenidaModel : ViewModelBase
{
    private NavigationService navegacionBienvenida;

    public MainBienvenidaModel(NavigationService navegacion)
    {
        navegacionBienvenida = navegacion;
    }
    
    [RelayCommand]
    public void NavegarGoogle()
    {
        navegacionBienvenida.NavigateTo("google");
    }
    
    [RelayCommand]
    public void NavegarCrear()
    {
        navegacionBienvenida.NavigateTo("crear");
    }
    
    [RelayCommand]
    public void NavegarLista()
    {
        navegacionBienvenida.NavigateTo("lista");
    }
    
}