using CommunityToolkit.Mvvm.ComponentModel;

namespace Proyecto_Productos_1ºEval.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _greeting = "Welcome to Avalonia!";
}