// Importa las librerías necesarias para trabajar con redes (HTTP) y JSON.
using System.Net;
using System.Text.Json;

namespace arreglos.Api.Middleware;

public class GlobalExceptionHandler
{
    // _next es un delegado que representa al siguiente middleware en el pipeline.
    // Es como un puntero a la "siguiente tarea" a realizar con la petición.
    private readonly RequestDelegate _next;

    // El constructor recibe el siguiente middleware y lo guarda.
    // ASP.NET Core se encarga de "inyectar" este delegado automáticamente.
    public GlobalExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    // Este es el método principal que se ejecuta para cada petición HTTP.
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Pasa el control al siguiente middleware en la cadena.
            // Si todo va bien aquí, la petición se procesa y se genera una respuesta.
            await _next(context); 
        }
        catch (Exception ex) // Si CUALQUIER middleware o el controlador lanza una excepción...
        {
            // ...la atrapamos aquí y la manejamos de forma controlada.
            await HandleExceptionAsync(context, ex);
        }
    }

    // Este método se encarga de formatear la respuesta de error.
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // 1. Establece valores por defecto para un error genérico.
        var statusCode = HttpStatusCode.InternalServerError; // Código 500
        var message = "Ocurrió un error interno en el servidor.";

        // 2. Personaliza la respuesta según el TIPO de excepción.
        // Si la excepción es de tipo ArgumentException (común para validaciones de entrada)...
        if (exception is ArgumentException)
        {
            // ...cambiamos el código a 400 (Mala Petición) y usamos el mensaje
            // de la propia excepción, que suele ser más descriptivo.
            statusCode = HttpStatusCode.BadRequest; 
            message = exception.Message;
        }

        // 3. Prepara la respuesta.
        // Crea un objeto anónimo y lo convierte a una cadena de texto JSON.
        // Ejemplo: { "error": "El ID proporcionado no es válido." }
        var result = JsonSerializer.Serialize(new { error = message });

        // Configura la respuesta HTTP que se enviará al cliente.
        context.Response.ContentType = "application/json"; // Indica que el contenido es JSON.
        context.Response.StatusCode = (int)statusCode; // Establece el código de estado (500, 400, etc.).

        // Escribe la cadena JSON en el cuerpo de la respuesta y la envía.
        return context.Response.WriteAsync(result);
    }
}