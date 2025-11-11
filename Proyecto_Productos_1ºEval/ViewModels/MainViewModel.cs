using CommunityToolkit.Mvvm.ComponentModel;
using Proyecto_Productos_1ºEval.Services;

namespace Proyecto_Productos_1ºEval.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] 
    private NavigationService navegacion = new();
}