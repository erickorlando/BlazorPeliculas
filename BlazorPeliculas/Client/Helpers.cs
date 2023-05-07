using Microsoft.JSInterop;

namespace BlazorPeliculas.Client;

public static class Helpers
{
    public static async ValueTask<bool> Confirm(this IJSRuntime js, string message)
    {
        // Cuando quiero ejecutar un metodo de JS sin retorno de datos

        await js.InvokeVoidAsync("console.log", "Prueba de Consola desde Blazor WASM");

        // Cuando requiero un valor de retorno de JS
        return await js.InvokeAsync<bool>("confirm", message);
    }
}