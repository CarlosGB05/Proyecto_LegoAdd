using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using Proyecto_Productos_1ºEval.Models;

namespace Proyecto_Productos_1ºEval.ViewModels;

public partial class MainEditarProductoModel: ViewModelBase
{
    [ObservableProperty]
    private Lego _lego = new();
    
    [RelayCommand]
    public void CerrarEditar()
    {
        DialogHost.Close("editar");
    }
    
    
}