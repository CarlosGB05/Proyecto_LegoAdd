using System;
using Avalonia.Controls;
using Newtonsoft.Json;

namespace Proyecto_Productos_1ºEval.Models;

public class Lego
{
    public int Id { get; set; }
    public string NumSet { get; set; } = String.Empty;
    public string Nombre { get; set; }
    public int Cantidad { get; set; } = 0;
    public string Categoria { get; set; } = String.Empty;
    public DateTime Fecha { get; set; } = DateTime.Today;
    public bool Disponible { get; set; } = false;
}