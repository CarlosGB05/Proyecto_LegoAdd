using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;
using Proyecto_Productos_1ºEval.ViewModels;
using Proyecto_Productos_1ºEval.Views;

namespace Proyecto_Productos_1ºEval.Services;

public partial class NavigationService:ObservableObject
{
    [ObservableProperty] 
    private ObservableCollection<NavigationViewItem> menuItems = new();
    
    [ObservableProperty] 
    private ContentControl vistaActual;
    
    [ObservableProperty]
    private NavigationViewItem menuSeleccionado;

    private NavigationViewItem itemGoogle;
    private NavigationViewItem itemHello;

    public NavigationService()
    {
        itemGoogle = new NavigationViewItem()
        {
            Content = "Inicio",
            Tag = "google",
            IconSource = new SymbolIconSource(){Symbol = Symbol.Home}
        };
        itemHello = new NavigationViewItem()
        {
            Content = "Tienda",
            Tag = "bienvenida",
            IconSource = new SymbolIconSource(){Symbol = Symbol.Shop}
        };
        
        MenuItems.Add(itemGoogle);
        MenuItems.Add(itemHello);
        
        NavigateTo("google");
    }

    public void NavigateTo(string tag)
    {
        if (tag.Equals("google"))
        {
            GoogleView registro = new GoogleView();
            registro.DataContext = new MainGoogleModel(this);
            VistaActual = registro;
            MenuSeleccionado = itemGoogle;
        }else if (tag.Equals("bienvenida"))
        {
            BienvenidaView menu = new BienvenidaView();
            menu.DataContext = new MainBienvenidaModel(this);
            VistaActual = menu;
            MenuSeleccionado = itemHello;
        }
    }
    
    partial void OnMenuSeleccionadoChanged(NavigationViewItem item)
    {
        NavigateTo(item.Tag.ToString());
    }
    
    
}