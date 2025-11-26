using System;
using Avalonia.Controls;

namespace Proyecto_Productos_1ºEval.Models;

public class Producto
{
    public string codigo { get; set; } = String.Empty;
    public string descripcion { get; set; } = String.Empty;
    public int cantidad { get; set; } = 0;
    public string categoria { get; set; } = String.Empty;
    public DateTime fecha { get; set; } = DateTime.Today;
    public bool disponible { get; set; } = false;
}