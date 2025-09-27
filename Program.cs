// 1. Importamos los namespaces de nuestros servicios para que este archivo los conozca.
using arreglos.Api.Services;
using arreglos.Api.Services.Contracts;
using arreglos.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Definicion de la política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendApp",
        policy =>
        {
            policy.AllowAnyOrigin() // En producción, cambiarías esto por la URL de tu app
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});



// --- Agrega los servicios al contenedor ---

// 2. Le decimos a la aplicación que vamos a usar el sistema de Controladores.
builder.Services.AddControllers();

// 3. Registramos nuestra regla de Inyección de Dependencias.
//    "Cuando un Controlador pida una interfaz devuelve una instancia concreta de la clase indicada."
builder.Services.AddScoped<IArrayService, ArrayService>();

var app = builder.Build();


//  --- Configura el Middleware personalizado para manejo global de errores ---
app.UseMiddleware<GlobalExceptionHandler>();

// --- Configura el pipeline de peticiones HTTP ---

// Comentamos temporalmente para debugging
app.UseHttpsRedirection();

// Uso la política de CORS que esta definida más arriba
app.UseCors("AllowFrontendApp");

// 4. Activamos el enrutamiento para que las peticiones (ej: /api/math/factorial)
//    lleguen a nuestros controladores.
app.MapControllers();


app.Run();