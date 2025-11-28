using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Collections;
using Newtonsoft.Json;
using Proyecto_Productos_1ºEval.Models;

namespace RepasoApp.Services;

public class APIService
{
    private HttpClient cliente;

    public APIService()
    {
        cliente = new HttpClient();
        cliente.BaseAddress = new Uri("http://192.160.50.22:7000");
        cliente.DefaultRequestHeaders.Add("apikey","eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyAgCiAgICAicm9sZSI6ICJhbm9uIiwKICAgICJpc3MiOiAic3VwYWJhc2UtZGVtbyIsCiAgICAiaWF0IjogMTY0MTc2OTIwMCwKICAgICJleHAiOiAxNzk5NTM1NjAwCn0.dc_X5iR_VP_qT0zsiyj_I_OZ2T9FtRU2BBNWN8Bu4GE");
        
    }

    public async Task CrearProducto(Lego lego)
    {
        var jsonP = JsonConvert.SerializeObject(lego);
        var request = new HttpRequestMessage(HttpMethod.Post, "rest/v1/productos")
        {
            Content = new StringContent(jsonP, Encoding.UTF8, "application/json")
        };
        var response = await cliente.SendAsync(request);
    }
    
    public async Task<bool> ModificarProducto(Lego lego)
    {
        var jsonP = JsonConvert.SerializeObject(lego);
        var request = new HttpRequestMessage(HttpMethod.Patch, "rest/v1/productos?id_producto=eq."+lego.Id)
        {
            Content = new StringContent(jsonP, Encoding.UTF8, "application/json")
        };
        request.Headers.Add("Prefer","return=presentation");
        var response = await cliente.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error al actualizar el producto");
        }
        var body = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(body))
        {
            throw new Exception("Error al actualizar el producto" +response.StatusCode);
        }

        return true;
    }
    
    public async Task<bool> EliminarProducto(Lego lego)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, "rest/v1/productos?id_producto=eq." + lego.Id);
        
        request.Headers.Add("Prefer","return=presentation");
        var response = await cliente.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error al eliminar el producto");
        }
        var body = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(body))
        {
            throw new Exception("Error al eliminar el producto" +response.StatusCode);
        }

        return true;
    }

    public async Task InsertarProducto()
    {
        
    }

    public async Task<AvaloniaList<Lego>> ObtenerProductos()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "rest/v1/productos");
        var response = await cliente.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<Lego>>(listaString);
    }

}