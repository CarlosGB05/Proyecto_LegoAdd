using System;
using System.Collections.Generic;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using Proyecto_Productos_1ºEval.Models;
using Proyecto_Productos_1ºEval.Services;
using Proyecto_Productos_1ºEval.Views.Dialogs;
using RepasoApp.Services;

namespace Proyecto_Productos_1ºEval.ViewModels;

public partial class MainListProductModel : ViewModelBase
{
    private NavigationService navegacionList;
    [ObservableProperty] private AvaloniaList<Lego> listaLegos = new();
    [ObservableProperty] private Lego legoSeleccionado = new();
    [ObservableProperty] private Lego legoEditar = new();
    [ObservableProperty] private List<string> categoria;
    [ObservableProperty] private bool verEditar = false;
    [ObservableProperty] private bool verEliminar = false;
    [ObservableProperty] private string mensaje = "";
    [ObservableProperty] private bool botonModificarLego = false;
    [ObservableProperty] private bool botonEliminarLego = false;

    public MainListProductModel(NavigationService navegacion)
    {
        navegacionList = navegacion;
        CargarListaLegos();
        CargarCategorias();
    }

    public MainListProductModel()
    {
        
    }

    [RelayCommand]
    public void NavegarCrear()
    {
        navegacionList.NavigateTo("crear");
    }
    
    [RelayCommand]
    public void NavegarBienvenida()
    {
        navegacionList.NavigateTo("bienvenida");
    }
    
    public void CargarCategorias()
    {
        categoria = new List<string>()
        {
            "Star Wars","Marvel","Ninjago","Batman","Ideas","Speed Champions"
        };
    }

    [RelayCommand]
    public void EditarProducto()
    {
        EditarProducto editar = new EditarProducto();
        editar.DataContext = new MainEditarProductoModel();
        DialogHost.Show(editar,"editar");
    }

    [RelayCommand]
    public void EliminarProducto()
    {
        EliminarProducto eliminar = new EliminarProducto();
        eliminar.DataContext = new MainEditarProductoModel();
        DialogHost.Show(eliminar,"eliminar");
    }
    
    public async void CargarListaLegos()
    {
        ListaLegos = await new DBService().ObtenerLegos();
    }
    
    [RelayCommand]
    public void CerrarEliminar()
    {
        DialogHost.Close("eliminar");
    }
    
    [RelayCommand]
    public void CerrarEditar()
    {
        DialogHost.Close("editar");
    }

    [RelayCommand]
    public void CargarLegoSelec()
    {
        if (LegoSeleccionado != null)
        {
            BotonEliminarLego = true;
            BotonModificarLego = true;
        }
        else
        {
            BotonEliminarLego = false;
            BotonModificarLego = false;
        }
    }
    
    [RelayCommand]
    public void VerEditarDialog()
    {
        VerEditar = !VerEditar;
    }
    
    [RelayCommand]
    public void VerEliminarDialog()
    {
        VerEliminar = !VerEliminar;
    }

    [RelayCommand]
    public async void ModificarLegoSelec()
    {
        ListaLegos = await new DBService().ModificarLego(legoSeleccionado);
        if (listaLegos != null)
        {
            VerEditar = !VerEditar;
        }
        else
        {
            Mensaje = "Error al editar";
        }
    }
    
    [RelayCommand]
    public async void EliminarLegoSelec()
    {
        ListaLegos = await new DBService().EliminarLego(legoSeleccionado);
        if (listaLegos != null)
        {
            VerEliminar = !VerEliminar;
        }
    }
}