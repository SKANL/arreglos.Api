using arreglos.Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using arreglos.Api.Models.Dtos;

namespace arreglos.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ArrayController : ControllerBase
{
    private readonly IArrayService _arrayService;

    public ArrayController(IArrayService arrayService)
    {
        _arrayService = arrayService;
    }

    // Endpoint para el Ejercicio 1: Contador de ceros en cada fila de una matriz.
    // Endpoint para el Ejercicio 2: Determina si una matriz es un cuadrado mágico y calcula su constante.
    // Endpoint para el Ejercicio 3: Realiza operaciones aritméticas (suma, resta, producto, división) entre dos matrices.

    // Endpoint para el Ejercicio 4: Genera una matriz identidad (diagonal de 1s, resto 0s) de un tamaño N.
    [HttpPost("identity")]
    public IActionResult GenerarMatrizIdentidad([FromBody] GenerarMatrizIdentidadRequest request)
    {
        // Verificar si el modelo es válido
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _arrayService.GenerarMatrizIdentidad(request.Size);
        var response = new GenerarMatrizIdentidadResponse(result);
        return Ok(response);
    }

    // Endpoint para el Ejercicio 5: Calcula la suma y el promedio de cada fila y columna en una matriz de números aleatorios.
    // Endpoint para el Ejercicio 6: Analiza una matriz de ventas para encontrar la venta mínima, máxima, total y por día.
    // Endpoint para el Ejercicio 7: Realiza un análisis estadístico de calificaciones de alumnos.
}