using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;

namespace Proyecto_Productos_1ºEval.ViewModels;

public partial class EliminarProductoModel: ViewModelBase
{
    [RelayCommand]
    public void CerrarEliminar()
    {
        DialogHost.Close("eliminar");
    }
}