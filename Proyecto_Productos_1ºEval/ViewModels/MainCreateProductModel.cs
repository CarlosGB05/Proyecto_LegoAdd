using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto_Productos_1ºEval.Models;
using Proyecto_Productos_1ºEval.Services;

namespace Proyecto_Productos_1ºEval.ViewModels;

public partial class MainCreateProductModel : ViewModelBase
{
    [ObservableProperty]
    private Producto producto = new();
    [ObservableProperty]
    private ObservableCollection<Producto> listaProductos = new();
    
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
            "Limpieza","Hogar","Jardineria","Informatica","Alimentacion"
        };
    }

    [RelayCommand]
    public void CrearProducto()
    {
        if (string.IsNullOrWhiteSpace(Producto.codigo))
        {
            Mensaje = "Codigo de Barras Incorrecto";
        }
        else if (string.IsNullOrWhiteSpace(Producto.descripcion))
        {
            Mensaje = "Descripcion Incorrecta";
        }
        else if (Producto.cantidad < 0)
        {
            Mensaje = "Cantidad Incorrecta";
        }
        else if (string.IsNullOrWhiteSpace(Producto.categoria))
        {
            Mensaje = "Categoria Incorrecta";
        }
        else if (Producto.fecha < DateTime.Today)
        {
            Mensaje = "Fecha Incorrecta";
        }
        else
        {
            ListaProductos.Add(Producto);
            Producto = new Producto();
            Mensaje = "Producto Creado Correctamente";
        }
    }
}