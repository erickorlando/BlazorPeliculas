using BlazorPeliculas.Shared.Entidades;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorPeliculas.Client.Pages;

public partial class Counter
{

    [Inject] private IJSRuntime js { get; set; } = null!;

    private int _currentCount = 0;
    private static int CurrentCount = 0;

    [JSInvokable]
    public async Task IncrementCount()
    {
        _currentCount++;
        CurrentCount++;
        await js.InvokeVoidAsync("pruebaPuntoNetStatic");
    }

    [JSInvokable]
    public static Task<int> ObtenerCurrentCount()
    {
        return Task.FromResult(CurrentCount);
    }

    private async Task IncrementCountJavaScript()
    {
        await js.InvokeVoidAsync("pruebaPuntoNetInstancia", DotNetObjectReference.Create(this));
    }

    private List<Pelicula> ObtenerPeliculas()
    {
        var list = new List<Pelicula>
        {
            new() { Titulo = "Spiderman 1", FechaLanzamiento = DateTime.Parse("2002-10-30") },
            new() { Titulo = "Inception", FechaLanzamiento = DateTime.Parse("2010-05-01") },
            new() { Titulo = "The Shutter Island", FechaLanzamiento = DateTime.Parse("2011-03-11")},
            new() { Titulo = "Captain America, The First Avenger", FechaLanzamiento = DateTime.Parse("2011-06-14")}
        };
        return list;
    }

}