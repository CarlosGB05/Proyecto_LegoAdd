using System;
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
    [ObservableProperty] private AvaloniaList<Lego> listaProductos = new();
    [ObservableProperty] private AvaloniaList<Lego> listaLegos = new();

    public MainListProductModel(NavigationService navegacion)
    {
        navegacionList = navegacion;
        CargarListaProductos();
        CargarListaLegos();
    }

    public MainListProductModel()
    {
        
    }

    public void CargarListaProductos()
    {
        Lego p = new Lego()
        {
            NumSet = "2121213",
            Cantidad = 4,
            Categoria = "Jardineria",
            Fecha = DateTime.Today
        };
        Lego p2 = new Lego()
        {
            NumSet = "2121214",
            Cantidad = 14,
            Categoria = "Hogar",
            Fecha = DateTime.Today
        };
        Lego p3 = new Lego()
        {
            NumSet = "2121214",
            Cantidad = 14,
            Categoria = "Hogar",
            Fecha = DateTime.Today
        };
        Lego p4 = new Lego()
        {
            NumSet = "2121214",
            Cantidad = 14,
            Categoria = "Hogar",
            Fecha = DateTime.Today
        };
        ListaProductos.Add(p);
        ListaProductos.Add(p2);
        ListaProductos.Add(p3);
        ListaProductos.Add(p4);
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
    
    public async void CargarListaLegos()
    {
        ListaLegos = await new DBService().ObtenerLegos();
    }
}