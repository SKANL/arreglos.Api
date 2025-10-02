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

    // Endpoint para el Ejercicio 1: Contador de ceros en cada fila de una matriz. (IMPLEMENTADO)
    [HttpPost("count-zeros")]
    public IActionResult ContarCerosPorFila([FromBody] ContarCerosRequest request)
    {
        // Llama al servicio para contar los ceros en cada fila.
        var resultado = _arrayService.ContarCerosPorFila(request.Matriz);
        var response = new ContarCerosResponse(resultado);
        return Ok(response);
    }

    // Endpoint para el Ejercicio 2: Determina si una matriz es un cuadrado mágico y calcula su constante. (IMPLEMENTADO)
    [HttpPost("magic-square")]
    public IActionResult VerificarCuadradoMagico([FromBody] EsCuadradoMagicoRequest request)
    {
        // Llama al servicio. El método devuelve un booleano y asigna la constante mágica a la variable 'constante'.
        bool esMagico = _arrayService.EsCuadradoMagico(request.Matriz, out int constante);

        // Crea la respuesta usando el DTO correspondiente.
        // Si es mágico, incluye la constante; si no, la constante será null.
        var response = new EsCuadradoMagicoResponse(esMagico, esMagico ? constante : null);

        return Ok(response);
    }

    // Endpoint para el Ejercicio 3: Realiza operaciones aritméticas (suma, resta, producto, división) entre dos matrices. (IMPLEMENTADO)
    [HttpPost("matrix-operations")]
    public IActionResult RealizarOperacionesMatrices([FromBody] OperacionesMatricesRequest request)
    {
        // Llama al servicio para realizar los cálculos.
        // El servicio se encarga de las validaciones de dimensiones.
        var response = _arrayService.RealizarOperacionesMatrices(request.MatrizA, request.MatrizB);
        return Ok(response);
    }

    // Endpoint para el Ejercicio 4: Genera una matriz identidad (diagonal de 1s, resto 0s) de un tamaño N. (IMPLEMENTADO)
    [HttpPost("identity")]
    public IActionResult GenerarMatrizIdentidad([FromBody] GenerarMatrizIdentidadRequest request)
    {
        // Verificar si el modelo es válido
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Nota: La validación del modelo (como [MustBePositive]) se maneja automáticamente
        // por el atributo [ApiController] en la clase. Si la validación falla,
        // se devuelve un error 400 Bad Request antes de que se ejecute este código.
        var result = _arrayService.GenerarMatrizIdentidad(request.Size);
        var response = new GenerarMatrizIdentidadResponse(result);
        return Ok(response);
    }

    // Endpoint para el Ejercicio 5: Calcula la suma y el promedio de cada fila y columna en una matriz de números aleatorios. (IMPLEMENTADO)
    [HttpPost("matrix-statistics")]
    public IActionResult CalcularEstadisticasMatriz([FromBody] CalcularEstadisticasMatrizRequest request)
    {
        // Llama al servicio para calcular las estadísticas de filas y columnas.
        var estadisticas = _arrayService.CalcularEstadisticasMatriz(request.Matriz);
        var response = new CalcularEstadisticasMatrizResponse(estadisticas);
        return Ok(response);
    }

    // Endpoint para el Ejercicio 6: Analiza una matriz de ventas para encontrar la venta mínima, máxima, total y por día. (IMPLEMENTADO)
    [HttpPost("sales-analysis")]
    public IActionResult AnalizarVentas([FromBody] AnalizarVentasRequest request)
    {
        var response = _arrayService.AnalizarVentas(request.Ventas);
        return Ok(response);
    }

    // Endpoint para el Ejercicio 7: Realiza un análisis estadístico de calificaciones de alumnos. (IMPLEMENTADO)
    [HttpPost("grades-analysis")]
    public IActionResult AnalizarCalificaciones([FromBody] AnalizarCalificacionesRequest request)
    {
        var response = _arrayService.AnalizarCalificaciones(request.Calificaciones);
        return Ok(response);
    }

    // Ejercicio 8: Revertir un arreglo usando recursión
    [HttpPost("reverse-array")]
    public IActionResult ReverseArray([FromBody] ReverseArrayRequest request)
    {
        var reversed = _arrayService.ReverseArrayRecursively(request.ArrayToReverse);
        return Ok(new ReverseArrayResponse(reversed));
    }

    // Ejercicio 9: Contar ocurrencias usando recursión
    [HttpPost("count-occurrences")]
    public IActionResult CountOccurrences([FromBody] CountOccurrencesRequest request)
    {
        var count = _arrayService.CountOccurrencesRecursively(request.Array, request.Value);
        return Ok(new CountOccurrencesResponse(count));
    }

    // Ejercicio 10: Aplanar matriz y calcular estadísticas usando OOP y recursión
    [HttpPost("flatten-stats")]
    public IActionResult FlattenStats([FromBody] CalcularEstadisticasMatrizRequest request)
    {
        // Reutilizamos el DTO de request de matriz int[][] existente para simplicidad.
        var stats = _arrayService.FlattenMatrixAndComputeStats(request.Matriz);
        return Ok(stats);
    }
}