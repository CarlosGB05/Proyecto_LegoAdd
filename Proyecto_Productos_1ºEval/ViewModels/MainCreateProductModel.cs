using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto_Productos_1ºEval.Models;
using Proyecto_Productos_1ºEval.Services;

namespace Proyecto_Productos_1ºEval.ViewModels;

public partial class MainCreateProductModel : ViewModelBase
{
    [ObservableProperty]
    private Lego lego = new();
    [ObservableProperty]
    private ObservableCollection<Lego> listaLego = new();
    
    [ObservableProperty]
    private List<string> categoria;
    
    [ObservableProperty]
    private string mensaje = string.Empty;
    
    private NavigationService navegacionCreate;

    public MainCreateProductModel(NavigationService navegacion)
    {
        navegacionCreate = navegacion;
        CargarCategorias();
    }

    public MainCreateProductModel()
    {
    }

    [RelayCommand]
    public void NavegarBienvenida()
    {
        navegacionCreate.NavigateTo("bienvenida");
    }
    
    [RelayCommand]
    public void NavegarLista()
    {
        navegacionCreate.NavigateTo("lista");
    }

    public void CargarCategorias()
    {
        categoria = new List<string>()
        {
            "Star Wars","Marvel","Ninjago","Batman","Ideas","Speed Champions"
        };
    }

    [RelayCommand]
    public async Task CrearLegoAsync()
    {
        if (string.IsNullOrWhiteSpace(Lego.NumSet))
        {
            Mensaje = "Numero del Set Incorrecto";
        }
        else if (string.IsNullOrWhiteSpace(Lego.Nombre))
        {
            Mensaje = "Nombre del Set Incorrecto";
        }
        else if (string.IsNullOrWhiteSpace(Lego.Categoria))
        {
            Mensaje = "Categoria del Set Incorrecto";
        }
        else if (Lego.Cantidad < 0)
        {
            Mensaje = "Numero de Piezas Incorrecta";
        }
        else
        {
            var authservice = new LegoAuthService();
            Lego legoCreado = await authservice.LoginAsync(Lego);
            Mensaje = "Set Lego Creado Correctamente";
        }
            
    }

    [RelayCommand]
    public void CancelarLego()
    {
        Lego =  new Lego();
        Mensaje = "Set Lego Cancelado";
    }

}