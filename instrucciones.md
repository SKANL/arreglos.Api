# Proyecto Arreglos API - Guía Completa

## Descripción General

Este proyecto es una **API REST educativa** desarrollada en **ASP.NET Core 9.0** que implementa algoritmos fundamentales de manipulación de matrices y arreglos. Está diseñado específicamente para **aprendizaje y demostración** de conceptos básicos de desarrollo de APIs, utilizando una arquitectura limpia y patrones de diseño modernos.

**Objetivo Principal**: Servir como proyecto base para entender los fundamentos de ASP.NET Core sin la complejidad de características empresariales avanzadas.

## Cómo Clonar y Ejecutar el Proyecto

### 🚀 Opción 1: Clonar desde GitHub (Recomendado)

Si quieres obtener el proyecto completo y funcional:

#### 1. Clonar el repositorio:
```bash
# Clonar el proyecto
git clone https://github.com/tu-usuario/arreglos-api.git

# Cambiar al directorio del proyecto
cd arreglos-api
```

#### 2. Verificar que tienes .NET instalado:
```bash
# Verificar versión de .NET (debe ser 9.0 o superior)
dotnet --version

# Si no tienes .NET 9.0, descárgalo desde:
# https://dotnet.microsoft.com/download/dotnet/9.0
```

#### 3. Restaurar dependencias:
```bash
# Restaurar paquetes NuGet
dotnet restore
```

#### 4. Compilar el proyecto:
```bash
# Compilar para verificar que todo está correcto
dotnet build

# Deberías ver: "Build succeeded"
```

#### 5. Ejecutar la aplicación:
```bash
# Ejecutar la API
dotnet run

# O para desarrollo con hot reload
dotnet watch run
```

#### 6. Verificar que funciona:
```bash
# La API debería estar corriendo en:
# http://localhost:5215

# Puedes probar con curl:
curl -X POST http://localhost:5215/api/array/identity \
  -H "Content-Type: application/json" \
  -d '{"size": 3}'
```

### 🛠️ Opción 2: Crear Proyecto desde Cero

Si prefieres entender el proceso de creación paso a paso:

#### Requisitos Previos
- .NET SDK 9.0 o superior
- Visual Studio Code o Visual Studio 2022
- Postman o Thunder Client (para pruebas de API)

#### Comandos de Creación Inicial
```bash
# Crear el proyecto de API Web
dotnet new webapi -n arreglos.Api -f net9.0

# Cambiar al directorio del proyecto
cd arreglos.Api

# Crear la estructura de carpetas
mkdir src
mkdir src/Attributes
mkdir src/Controllers
mkdir src/Services
mkdir src/Services/Contracts
mkdir src/Models
mkdir src/Models/DTOs
mkdir src/Middleware
```

### ⚠️ Problemas Comunes al Clonar

#### Error: "git no se reconoce como comando"
**Solución**: Instalar Git desde https://git-scm.com/

#### Error: "dotnet no se reconoce como comando"
**Solución**: 
1. Instalar .NET SDK desde https://dotnet.microsoft.com/download
2. Reiniciar terminal después de la instalación
3. Verificar con: `dotnet --version`

#### Error: "Puerto 5215 ya está en uso"
**Solución**:
```bash
# En Windows
netstat -ano | findstr 5215
taskkill /PID [número_del_proceso] /F

# En Mac/Linux
lsof -i :5215
kill -9 [PID]
```

#### Error: "Build failed" o errores de compilación
**Solución**:
```bash
# Limpiar y reconstruir
dotnet clean
dotnet restore
dotnet build
```

#### Error: "No such host is known" al hacer requests
**Verificar**:
- ✅ La API está corriendo (deberías ver logs en la consola)
- ✅ Usas la URL correcta: `http://localhost:5215`
- ✅ Incluyes `Content-Type: application/json` en el header

### 🧪 Verificar que Todo Funciona

#### Prueba con curl (Terminal):
```bash
# Test básico
curl -X POST http://localhost:5215/api/array/identity \
  -H "Content-Type: application/json" \
  -d '{"size": 3}'

# Deberías obtener:
# {"matriz":[[1,0,0],[0,1,0],[0,0,1]]}
```

#### Prueba con PowerShell (Windows):
```powershell
# Test con PowerShell
$body = @{
    size = 3
} | ConvertTo-Json

Invoke-RestMethod -Uri "http://localhost:5215/api/array/identity" `
  -Method Post `
  -Body $body `
  -ContentType "application/json"
```

#### Prueba con Postman/Thunder Client:
1. **Method**: POST
2. **URL**: `http://localhost:5215/api/array/identity`
3. **Headers**: `Content-Type: application/json`
4. **Body** (raw JSON):
```json
{
  "size": 3
}
```

### 📁 Estructura Esperada Después de Clonar

Después de clonar exitosamente, deberías tener esta estructura:

## Arquitectura y Estructura del Proyecto

```
arreglos.Api/
├── Program.cs                          # Punto de entrada de la aplicación
├── appsettings.json                    # Configuración general
├── appsettings.Development.json        # Configuración de desarrollo
├── arreglos.Api.csproj                 # Archivo de proyecto
├── Properties/
│   └── launchSettings.json             # Configuración de ejecución
└── src/
    ├── Attributes/                     # Atributos de validación personalizados
    │   └── MustBePositiveAttribute.cs
    ├── Controllers/                    # Controladores de la API
    │   └── ArrayController.cs
    ├── Services/                       # Lógica de negocio
    │   ├── ArrayService.cs
    │   └── Contracts/
    │       └── IArrayService.cs
    ├── Models/
    │   └── DTOs/
    │       └── ArrayDtos.cs            # Objetos de transferencia de datos
    └── Middleware/
        └── GlobalExceptionHandler.cs   # Manejo global de excepciones
```

## Decisiones Técnicas Clave

### 1. Arquitectura por Capas (Separación de Responsabilidades)
- **Controllers**: Actúan como punto de entrada HTTP, reciben requests, validan datos básicos y devuelven responses. No contienen lógica de negocio.
- **Services**: Encapsulan toda la lógica de negocio y algoritmos. Son independientes del protocolo HTTP y pueden ser reutilizados.
- **DTOs (Data Transfer Objects)**: Definen contratos claros de entrada y salida, proporcionando validación automática y serialización JSON.
- **Middleware**: Maneja aspectos transversales como excepciones globales, logging y validación de requests.
- **Attributes**: Contienen validaciones personalizadas reutilizables que se aplican automáticamente a los DTOs.

### 2. Inyección de Dependencias (Inversión de Control)
```csharp
// En Program.cs
builder.Services.AddScoped<IArrayService, ArrayService>();
```
**¿Por qué es importante?**
- **Desacoplamiento**: Los controladores no dependen directamente de implementaciones concretas
- **Testabilidad**: Fácil crear mocks e implementaciones de prueba
- **Mantenibilidad**: Cambiar implementaciones sin modificar el código que las usa
- **Principios SOLID**: Especialmente el principio de Inversión de Dependencias
- **Ciclo de vida controlado**: ASP.NET Core maneja automáticamente la creación y destrucción de objetos

### 3. Manejo Global de Excepciones (Middleware Personalizado)
```csharp
app.UseMiddleware<GlobalExceptionHandler>();
```
**¿Qué hace exactamente?**
- **Intercepta errores**: Captura cualquier excepción que no fue manejada en Controllers o Services
- **Respuestas uniformes**: Todos los errores devuelven el mismo formato JSON consistente
- **Seguridad**: Oculta detalles técnicos internos (como stack traces) del cliente
- **Logging centralizado**: Un solo lugar para registrar todos los errores de la aplicación
- **Códigos HTTP apropiados**: Convierte excepciones .NET en códigos de estado HTTP correctos (400, 404, 500, etc.)

### 4. CORS Permisivo para Desarrollo
```csharp
policy.AllowAnyOrigin()
      .AllowAnyHeader()
      .AllowAnyMethod();
```
**¿Qué es CORS y por qué lo necesitamos?**
- **Cross-Origin Resource Sharing**: Política de seguridad de navegadores web
- **El problema**: Por defecto, una página web en `http://localhost:3000` no puede llamar a una API en `http://localhost:5215`
- **Nuestra solución**: Configuración permisiva que permite requests desde cualquier origen
- **Para desarrollo**: Perfecto para testing con Postman, Thunder Client, o frontend local
- **⚠️ IMPORTANTE**: En producción debes especificar orígenes específicos por seguridad

### 5. Tipo de Datos para Matrices (Decisión Técnica Crítica)
**Problema Encontrado**: Cambio de `int[,]` a `int[][]`

**El Error Original**:
```csharp
public record GenerarMatrizIdentidadResponse(int[,] Matriz); // ❌ Error de serialización
```
**Resultado**: El JSON aparecía vacío `{"matriz": {}}` en lugar de mostrar el array.

**La Solución Implementada**:
```csharp
public record GenerarMatrizIdentidadResponse(int[][] Matriz); // ✅ Funciona perfectamente
```
**Resultado**: JSON correcto `{"matriz": [[1,0,0],[0,1,0],[0,0,1]]}`

**¿Por qué ocurre esto?**
- `int[,]` = **Array multidimensional**: Una sola instancia en memoria con múltiples dimensiones
- `int[][]` = **Array de arrays**: Un array que contiene referencias a otros arrays
- **System.Text.Json** (serializador por defecto) solo entiende la segunda estructura
- Esta es una limitación conocida de .NET, no un bug de nuestro código

### 6. Atributos de Validación Personalizados (Validación Declarativa)
```csharp
[MustBePositive(1)] // Valida automáticamente que el valor sea >= 1
public int Size { get; init; }
```
**¿Cómo funciona la magia?**
- **MustBePositiveAttribute**: Nuestro validador personalizado que hereda de `ValidationAttribute`
- **Ejecución automática**: ASP.NET Core ejecuta la validación antes de que llegue al Controller
- **Mensajes contextuales**: Detecta si valida "size" o "tamaño" y ajusta el mensaje de error
- **Múltiples tipos**: Funciona con int, long, short, byte automáticamente
- **Error HTTP 400**: Si la validación falla, devuelve Bad Request antes de ejecutar tu código

**Ventaja clave**: Tu Controller recibe datos ya validados, no necesitas verificar manualmente.
- Integración automática con el sistema de validación de ASP.NET Core

## Filosofía del Proyecto: Simplicidad y Enfoque Educativo

### ¿Por qué este proyecto NO incluye características "empresariales"?

Este proyecto está **intencionalmente simplificado** para enfocarse en los conceptos fundamentales de ASP.NET Core. Aquí explicamos qué NO incluimos y por qué:

#### 🚫 **No incluye Swagger/OpenAPI**
**¿Por qué no?**
- **Enfoque en lo esencial**: Queremos que te concentres en la lógica de la API, no en la documentación automática
- **Menos dependencias**: Mantiene el proyecto ligero y fácil de entender
- **Testing manual**: Fomenta el uso de herramientas como Postman o Thunder Client para entender mejor las peticiones HTTP

**¿Cuándo sí usarías Swagger?** En proyectos empresariales con múltiples equipos que necesitan documentación automática.

#### 🚫 **No incluye JWT (Autenticación/Autorización)**
**¿Por qué no?**
- **Complejidad innecesaria**: Los algoritmos de matrices no requieren usuarios ni permisos
- **Enfoque en algoritmos**: El valor del proyecto está en la lógica de negocio, no en la seguridad
- **Simplicidad de testing**: Puedes probar endpoints directamente sin tokens

**¿Cuándo sí usarías JWT?** En APIs que manejan datos sensibles o requieren control de acceso por usuario.

#### 🚫 **No incluye Base de Datos**
**¿Por qué no?**
- **Stateless**: Los algoritmos de matrices son operaciones puras sin necesidad de persistencia
- **Enfoque en lógica**: No queremos distraerte con configuración de Entity Framework o SQL
- **Menos configuración**: Arrancar el proyecto es inmediato, sin setup de base de datos

**¿Cuándo sí usarías DB?** Cuando necesites persistir datos, usuarios, o historial de operaciones.

#### 🚫 **No incluye Logging Avanzado (Serilog)**
**¿Por qué no?**
- **Console suficiente**: Para aprendizaje, los logs en consola son más que suficientes
- **Menos configuración**: No necesitas configurar providers externos
- **Debugging simple**: `dotnet run` te muestra todo lo que necesitas

**¿Cuándo sí usarías Serilog?** En producción donde necesitas logs estructurados y múltiples destinos.

#### 🚫 **No incluye HTTPS Obligatorio**
**¿Por qué no?**
- **Desarrollo local**: Simplifica las pruebas en localhost
- **Sin certificados**: No necesitas configurar certificados SSL/TLS
- **Foco en funcionalidad**: Te concentras en la API, no en la seguridad de transporte

**¿Cuándo sí usarías HTTPS?** Siempre en producción, especialmente con datos sensibles.

### 🎯 **¿Cuál es el punto entonces?**

Este proyecto te enseña:
- ✅ **Arquitectura limpia**: Separación clara de responsabilidades
- ✅ **Inyección de dependencias**: Patrón fundamental en .NET
- ✅ **Validación automática**: Data Annotations y atributos personalizados
- ✅ **Manejo de errores**: Middleware global para excepciones
- ✅ **Serialización JSON**: DTOs y personalización de response
- ✅ **Testing manual**: Usando herramientas REST

**Una vez que domines estos conceptos**, estarás preparado para agregar las características empresariales que necesites.

## Conceptos Importantes que Debes Conocer

### 📋 ¿Por qué usamos `record` en lugar de `class` para los DTOs?

#### Implementación actual:
```csharp
// ✅ Usando record (como está en el proyecto)
public record GenerarMatrizIdentidadRequest(
    [MustBePositive] 
    [Range(1, 1000, ErrorMessage = "El tamaño debe estar entre 1 y 1000")]
    int Size
);

// ❌ Si fuera class (más código, menos eficiente)
public class GenerarMatrizIdentidadRequest
{
    public int Size { get; set; }
    
    // Necesitarías escribir manualmente:
    // - Constructor
    // - Equals y GetHashCode
    // - ToString
    // - Validaciones en propiedades separadas
}
```

#### **Ventajas de `record` para DTOs:**

1. **🚀 Inmutabilidad por defecto**: Los datos no pueden cambiar después de crearse
   ```csharp
   var request = new GenerarMatrizIdentidadRequest(Size: 5);
   // request.Size = 10; // ❌ Error de compilación - no se puede modificar
   ```

2. **⚡ Menos código**: Constructor, Equals, GetHashCode y ToString automáticos
3. **🔒 Seguridad**: Previene modificaciones accidentales de datos
4. **📊 Comparación por valor**: Dos records con los mismos datos son iguales
   ```csharp
   var request1 = new GenerarMatrizIdentidadRequest(Size: 3);
   var request2 = new GenerarMatrizIdentidadRequest(Size: 3);
   Console.WriteLine(request1 == request2); // ✅ True (con record)
   ```

5. **🎯 Perfecto para DTOs**: Los DTOs solo transportan datos, no necesitan comportamiento mutable

### 🏷️ ¿Por qué usamos Atributos en lugar de validación manual?

#### Enfoque con atributos (actual):
```csharp
public record GenerarMatrizIdentidadRequest(
    [MustBePositive] 
    [Range(1, 1000)]
    int Size  // ← Validación declarativa
);

[HttpPost("identity")]
public IActionResult GenerarMatrizIdentidad([FromBody] GenerarMatrizIdentidadRequest request)
{
    // ✅ Los datos ya están validados automáticamente
    var result = _arrayService.GenerarMatrizIdentidad(request.Size);
    return Ok(new GenerarMatrizIdentidadResponse(result));
}
```

#### Sin atributos (enfoque manual):
```csharp
public record GenerarMatrizIdentidadRequest(int Size);

[HttpPost("identity")]
public IActionResult GenerarMatrizIdentidad([FromBody] GenerarMatrizIdentidadRequest request)
{
    // ❌ Validación manual en cada endpoint
    if (request.Size <= 0)
        return BadRequest("Size debe ser positivo");
        
    if (request.Size > 1000)
        return BadRequest("Size máximo es 1000");
    
    // ... más validaciones manuales
    
    var result = _arrayService.GenerarMatrizIdentidad(request.Size);
    return Ok(new GenerarMatrizIdentidadResponse(result));
}
```

#### **Ventajas de los atributos:**
- **🔄 Reutilización**: `[MustBePositive]` se puede usar en múltiples DTOs
- **🧹 Código limpio**: Controllers solo se enfocan en la lógica de negocio
- **🚀 Automático**: ASP.NET Core ejecuta validaciones antes del Controller
- **📝 Declarativo**: Las reglas están visibles junto a las propiedades

### 🎯 ¿Por qué separamos Interface y Implementation en Services?

#### Estructura actual:
```csharp
// Interface (contrato)
public interface IArrayService
{
    int[][] GenerarMatrizIdentidad(int size);
}

// Implementación (lógica real)
public class ArrayService : IArrayService
{
    public int[][] GenerarMatrizIdentidad(int size) { /* ... */ }
}

// Inyección en Program.cs
builder.Services.AddScoped<IArrayService, ArrayService>();
```

#### **¿Por qué no hacer esto directamente?**
```csharp
// ❌ Sin interface
public class ArrayService
{
    public int[][] GenerarMatrizIdentidad(int size) { /* ... */ }
}

// En el controller
public ArrayController(ArrayService arrayService) // ← Acoplamiento directo
```

#### **Ventajas de usar Interfaces:**

1. **🔧 Testing fácil**: Puedes crear mocks para pruebas unitarias
   ```csharp
   // En tests
   var mockService = new Mock<IArrayService>();
   mockService.Setup(x => x.GenerarMatrizIdentidad(3))
           .Returns(new int[][] { /* matriz mock */ });
   ```

2. **🔄 Intercambiabilidad**: Cambiar implementación sin tocar Controllers
   ```csharp
   // Cambiar de ArrayService a ArrayServiceV2 sin modificar Controllers
   builder.Services.AddScoped<IArrayService, ArrayServiceV2>();
   ```

3. **📋 Contrato claro**: La interface define qué hace, no cómo lo hace
4. **🏗️ Principios SOLID**: Especialmente "Dependency Inversion Principle"

### 🌐 ¿Por qué ASP.NET Core convierte nombres a camelCase automáticamente?

#### Lo que escribes en C#:
```csharp
public record GenerarMatrizIdentidadResponse(int[][] Matriz);
```

#### Lo que aparece en JSON:
```json
{
  "matriz": [[1,0,0],[0,1,0],[0,0,1]]
}
```

#### **Razones técnicas:**

1. **🌍 Estándar web**: JavaScript y APIs REST usan camelCase por convención
2. **🔄 Interoperabilidad**: Frontend frameworks esperan camelCase
3. **📱 Consistencia**: Otras APIs .NET también usan esta conversión
4. **⚡ Automático**: No necesitas configurar nada, funciona "out of the box"

#### **Puedes desactivarlo si quieres:**
```csharp
// En Program.cs
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null; // Desactiva camelCase
});
```

### 🛡️ ¿Por qué usamos `int[][]` en lugar de `List<List<int>>`?

#### Comparación:

```csharp
// ✅ Array de arrays (actual)
public record GenerarMatrizIdentidadResponse(int[][] Matriz);

// ❌ Lista de listas (alternativa)
public record GenerarMatrizIdentidadResponse(List<List<int>> Matriz);
```

#### **Ventajas de `int[][]`:**

1. **⚡ Performance**: Arrays son más rápidos que Lists para acceso por índice
2. **💾 Memoria**: Menos overhead de memoria (no metadatos de List)
3. **🎯 Inmutabilidad**: Con `record`, el array no puede ser reemplazado
4. **📏 Tamaño fijo**: Las matrices tienen tamaño conocido, no necesitan redimensionamiento
5. **🔧 Serialización**: System.Text.Json maneja arrays nativamente

#### **Cuándo usar `List<T>`:**
- Cuando necesitas agregar/quitar elementos dinámicamente
- Cuando el tamaño es variable e impredecible

## Configuración del Proyecto

### 1. Configuración de HTTPS (Comentado para Desarrollo)
```csharp
// app.UseHttpsRedirection(); // Comentado para simplificar desarrollo local
```

### 2. Puerto de Desarrollo
- **HTTP**: localhost:5215
- Configurado en `Properties/launchSettings.json`

### 3. Variables de Entorno
```json
{
  "environmentName": "Development",
  "applicationUrl": "http://localhost:5215"
}
```

## Personalización Simple de Request y Response (JSON)

### Cómo funciona actualmente el proyecto

El proyecto usa un enfoque **simple y directo** sin configuraciones JSON complejas. Veamos cómo está implementado:

#### Request DTO Real:
```csharp
// En src/Models/DTOs/ArrayDtos.cs
public record GenerarMatrizIdentidadRequest(
    [MustBePositive] 
    [Range(1, 1000, ErrorMessage = "El tamaño de la matriz debe estar entre 1 y 1000 para evitar problemas de memoria.")]
    [Display(Name = "Tamaño de la matriz")]
    int Size
);
```

#### Response DTO Real:
```csharp
public record GenerarMatrizIdentidadResponse(int[][] Matriz);
```

#### JSON Request que funciona:
```json
{
  "size": 3
}
```

#### JSON Response que obtienes:
```json
{
  "matriz": [
    [1, 0, 0],
    [0, 1, 0],
    [0, 0, 1]
  ]
}
```

### ¿Por qué los nombres cambian automáticamente?

**ASP.NET Core por defecto**:
- Convierte `Size` (C#) → `"size"` (JSON) 
- Convierte `Matriz` (C#) → `"matriz"` (JSON)
- Usa **camelCase** automáticamente para propiedades JSON

### Personalizar nombres si quieres (Opcional)

Si necesitas cambiar los nombres JSON, puedes agregar:

```csharp
using System.Text.Json.Serialization;

// Request personalizado
public record GenerarMatrizRequest(
    [JsonPropertyName("tamaño")] int Size  // Ahora aparece como "tamaño" en JSON
);

// Response personalizado  
public record MatrizResponse(
    [JsonPropertyName("matriz_resultado")] int[][] Matriz
);
```

**Resultado JSON**:
```json
{
  "tamaño": 3
}
```

### Validaciones Reales del Proyecto

El proyecto ya implementa validación robusta:

```csharp
public record GenerarMatrizIdentidadRequest(
    [MustBePositive]  // ← Atributo personalizado del proyecto
    [Range(1, 1000, ErrorMessage = "El tamaño de la matriz debe estar entre 1 y 1000 para evitar problemas de memoria.")]
    [Display(Name = "Tamaño de la matriz")]  // ← Nombre amigable para errores
    int Size
);
```

**Si envías un valor inválido**:
```json
{
  "size": -1
}
```

**Obtienes error automático**:
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Size": [
      "El tamaño de la matriz debe ser mayor o igual a 1."
    ]
  }
}
```

## Cómo Editar y Extender el Proyecto

### Agregar un Nuevo Endpoint

#### 1. Definir DTOs
```csharp
// En src/Models/DTOs/ArrayDtos.cs
public record NuevoAlgoritmoRequest(int[] Numeros);
public record NuevoAlgoritmoResponse(int Resultado);
```

#### 2. Agregar Método al Servicio
```csharp
// En src/Services/Contracts/IArrayService.cs
public interface IArrayService
{
    int[][] GenerarMatrizIdentidad(int size);
    int NuevoAlgoritmo(int[] numeros); // ← Nuevo método
}

// En src/Services/ArrayService.cs
public int NuevoAlgoritmo(int[] numeros)
{
    // Implementar lógica aquí
    return numeros.Sum();
}
```

#### 3. Agregar Endpoint al Controlador
```csharp
// En src/Controllers/ArrayController.cs
[HttpPost("nuevo-algoritmo")]
public IActionResult NuevoAlgoritmo([FromBody] NuevoAlgoritmoRequest request)
{
    var result = _arrayService.NuevoAlgoritmo(request.Numeros);
    var response = new NuevoAlgoritmoResponse(result);
    return Ok(response);
}
```

### Crear Atributos de Validación Personalizados

#### 1. Crear Nuevo Atributo de Validación
```csharp
// En src/Attributes/MiValidacionAttribute.cs
using System.ComponentModel.DataAnnotations;

namespace arreglos.Api.Attributes;

public class MiValidacionAttribute : ValidationAttribute
{
    private readonly string _parametro;

    public MiValidacionAttribute(string parametro)
    {
        _parametro = parametro;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        // Implementar lógica de validación
        if (value == null || !EsValido(value))
        {
            return new ValidationResult($"Error de validación: {ErrorMessage}");
        }

        return ValidationResult.Success;
    }

    private bool EsValido(object value)
    {
        // Tu lógica de validación aquí
        return true;
    }

    public override string FormatErrorMessage(string name)
    {
        return $"El campo {name} no cumple con la validación requerida.";
    }
}
```

#### 2. Usar el Atributo en DTOs
```csharp
// En src/Models/DTOs/ArrayDtos.cs
public record MiRequest(
    [property: MiValidacion("parametro")] string Valor
);
```

### Personalizar Manejo de Errores

#### Agregar Nuevos Tipos de Excepción
```csharp
// En src/Middleware/GlobalExceptionHandler.cs
private static Task HandleExceptionAsync(HttpContext context, Exception exception)
{
    var statusCode = HttpStatusCode.InternalServerError;
    var message = "Ocurrió un error interno en el servidor.";

    // Agregar nuevos tipos de excepción
    if (exception is ArgumentException)
    {
        statusCode = HttpStatusCode.BadRequest;
        message = exception.Message;
    }
    else if (exception is InvalidOperationException) // ← Nuevo tipo
    {
        statusCode = HttpStatusCode.UnprocessableEntity;
        message = "Operación no válida: " + exception.Message;
    }

    // ... resto del código
}
```

### Configurar para Producción

#### 1. Habilitar HTTPS
```csharp
// Descomentar en Program.cs
app.UseHttpsRedirection();
```

#### 2. Configurar CORS Específico
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("ProductionPolicy",
        policy =>
        {
            policy.WithOrigins("https://mi-dominio.com") // ← URL específica
                  .WithMethods("GET", "POST")
                  .WithHeaders("Content-Type");
        });
});
```

#### 3. Configurar Logging
```csharp
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddFile("logs/app-{Date}.txt"); // Requiere Serilog
```

## Comandos Útiles

### Desarrollo
```bash
# Ejecutar la aplicación
dotnet run

# Ejecutar con hot reload
dotnet watch run

# Compilar sin ejecutar
dotnet build

# Limpiar builds anteriores
dotnet clean
```

### Testing
```bash
# Crear proyecto de pruebas
dotnet new xunit -n arreglos.Api.Tests

# Ejecutar pruebas
dotnet test
```

### Producción
```bash
# Publicar para producción
dotnet publish -c Release -o ./publish

# Ejecutar desde publicación
dotnet ./publish/arreglos.Api.dll
```

## Ejemplos de Uso de la API

### Generar Matriz Identidad
```bash
# Petición
POST http://localhost:5215/api/array/identity
Content-Type: application/json

{
    "Size": 3
}

# Respuesta
{
    "matriz": [
        [1, 0, 0],
        [0, 1, 0],
        [0, 0, 1]
    ]
}
```

## Resolución de Problemas Comunes

### 🚨 Error 500 - Internal Server Error
**¿Qué significa?** El servidor encontró un error inesperado y no pudo completar la petición.

**Pasos para solucionarlo:**
1. **🔍 Verificar logs en la consola** donde ejecutaste `dotnet run` - aquí aparecerá el error real
2. **📊 Problema común**: Serialización de arrays multidimensionales (`int[,]`)
3. **✅ Solución**: Cambiar a `int[][]` en tus DTOs
4. **🔧 Otros casos**: Excepción no capturada en el Service, problemas de inyección de dependencias

### 🚫 Error de CORS (Blocked by CORS policy)
**¿Qué significa?** Tu navegador bloqueó la petición porque viene de un origen no autorizado.

**Diagnóstico:**
- 🟢 **Postman/Thunder Client funcionan**: El problema es CORS (solo afecta navegadores)
- 🔴 **Postman también falla**: El problema NO es CORS, es otra cosa

**Solución:**
1. **Verificar configuración** en `Program.cs` - debe tener `builder.Services.AddCors()`
2. **Verificar orden** de middlewares - `app.UseCors()` debe ir ANTES que `app.MapControllers()`
3. **Verificar que esté aplicado** - `policy.AllowAnyOrigin()` debe estar presente

### 📦 Error de Inyección de Dependencias
**Errores típicos:**
- `Unable to resolve service for type 'IArrayService'`
- `No service for type has been registered`

**Solución:**
1. **🔍 Verificar registro** en `Program.cs`:
   ```csharp
   builder.Services.AddScoped<IArrayService, ArrayService>(); // ¿Está esta línea?
   ```
2. **📝 Verificar namespaces** - ¿Están importados los `using` correctos?
3. **🎯 Verificar nombres** - ¿IArrayService y ArrayService existen y tienen los nombres correctos?

### 🔥 Error de Compilación
**Pasos rápidos:**
1. **Limpiar y recompilar**:
   ```bash
   dotnet clean
   dotnet build
   ```
2. **Verificar referencias** - ¿Todos los `using` están correctos?
3. **Verificar sintaxis** - ¿Puntos y comas, llaves, paréntesis?

### 🗺️ Puerto ya en uso
**Error**: `Address already in use`

**Solución rápida**:
```bash
# Encontrar proceso usando el puerto 5215
netstat -ano | findstr 5215

# Matar el proceso (reemplaza PID con el número encontrado)
taskkill /PID 1234 /F
```

## Extensiones Recomendadas para VS Code
- C# Dev Kit
- REST Client
- Thunder Client
- GitLens
- Auto Rename Tag