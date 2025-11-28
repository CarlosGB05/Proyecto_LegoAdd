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
    private NavigationViewItem itemCreate;
    private NavigationViewItem itemList;
    private NavigationViewItem itemService;

    public NavigationService()
    {
        itemGoogle = new NavigationViewItem()
        {
            Content = "Registro",
            Tag = "google",
            IconSource = new SymbolIconSource(){Symbol = Symbol.Home}
        };
        itemHello = new NavigationViewItem()
        {
            Content = "Inicio",
            Tag = "bienvenida",
            IconSource = new SymbolIconSource(){Symbol = Symbol.Shop}
        };
        itemCreate = new NavigationViewItem()
        {
            Content = "Crear Lego",
            Tag = "crear",
            IconSource = new SymbolIconSource() { Symbol = Symbol.Phone }
        };
        itemList = new NavigationViewItem()
        {
            Content = "Lista de Legos",
            Tag = "lista",
            IconSource = new SymbolIconSource() { Symbol = Symbol.Library }
        };
        
        MenuItems.Add(itemGoogle);
        MenuItems.Add(itemHello);
        MenuItems.Add(itemCreate);
        MenuItems.Add(itemList);
        
        NavigateTo("google");
    }

    public void NavigateTo(string tag)
    {
        if (tag.Equals("google"))
        {
            GoogleView registro = new GoogleView();
            registro.DataContext = new MainGoogleViewModel(this);
            VistaActual = registro;
            MenuSeleccionado = itemGoogle;
        }
        else if (tag.Equals("bienvenida"))
        {
            BienvenidaView menu = new BienvenidaView();
            menu.DataContext = new MainBienvenidaModel(this);
            VistaActual = menu;
            MenuSeleccionado = itemHello;
        }
        else if (tag.Equals("crear"))
        {
            CreateProductView create = new CreateProductView();
            create.DataContext = new MainCreateProductModel(this);
            VistaActual = create;
            MenuSeleccionado = itemCreate;
        }
        else if (tag.Equals("lista"))
        {
            ListProductView list = new ListProductView();
            list.DataContext = new MainListProductModel(this);
            VistaActual = list;
            MenuSeleccionado = itemList;
        }
    }
    
    partial void OnMenuSeleccionadoChanged(NavigationViewItem item)
    {
        NavigateTo(item.Tag.ToString());
    }
    
    
}