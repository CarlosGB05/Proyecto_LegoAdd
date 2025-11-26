using System;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using Proyecto_Productos_1ºEval.Models;
using Proyecto_Productos_1ºEval.Services;
using Proyecto_Productos_1ºEval.Views.Dialogs;

namespace Proyecto_Productos_1ºEval.ViewModels;

public partial class MainListProductModel : ViewModelBase
{
    private NavigationService navegacionList;
    [ObservableProperty] private AvaloniaList<Producto> listaProductos = new();

    public MainListProductModel(NavigationService navegacion)
    {
        navegacionList = navegacion;
        CargarListaProductos();
    }

    public MainListProductModel()
    {
        
    }

    public void CargarListaProductos()
    {
        Producto p = new Producto()
        {
            codigo = "2121213",
            descripcion = "Cod Ejemplo",
            cantidad = 4,
            categoria = "Jardineria",
            fecha = DateTime.Today
        };
        Producto p2 = new Producto()
        {
            codigo = "2121214",
            descripcion = "Cod Ejemplo 2",
            cantidad = 14,
            categoria = "Hogar",
            fecha = DateTime.Today
        };
        ListaProductos.Add(p);
        ListaProductos.Add(p2);
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
}