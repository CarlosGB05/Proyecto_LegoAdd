using System;

namespace Proyecto_Productos_1ºEval.Models;

public class Usuario
{
    public int Id { get; set; }
    public string GoogleSub {get; set;}
    public string Email {get; set;}
    public string Nombre {get; set;}
    public string Imagen {get; set;}
    public string RefreshToken {get; set;}
    public DateTime UltimoLogin {get; set;}
    public DateTime FechaRegistro {get; set;} = DateTime.Now;
}