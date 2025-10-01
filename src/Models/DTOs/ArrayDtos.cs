using arreglos.Api.Attributes;

namespace arreglos.Api.Models.Dtos;

// Ejercicio 1: Contador de ceros en cada fila de una matriz. (IMPLEMENTADO)
public record ContarCerosRequest(int[][] Matriz);
public record ContarCerosResponse(int[] CerosPorFila);


// Ejercicio 2: Determina si una matriz es un cuadrado mágico y calcula su constante. (YA IMPLEMENTADO)
public record EsCuadradoMagicoRequest(int[][] Matriz);
public record EsCuadradoMagicoResponse(bool EsMagico, int? ConstanteMagica);

// Ejercicio 3: Realiza operaciones aritméticas (suma, resta, producto, división) entre dos matrices. (YA IMPLEMENTADO)
public record OperacionesMatricesRequest(int[][] MatrizA, int[][] MatrizB);
public record OperacionesMatricesResponse(int[][] Suma, int[][] Resta, int[][] Producto, double[][] Division);

// Ejercicio 4: Genera una matriz identidad (diagonal de 1s, resto 0s) de un tamaño N. (YA IMPLEMENTADO)
public record GenerarMatrizIdentidadRequest([MustBePositive] int Size);
public record GenerarMatrizIdentidadResponse(int[][] Matriz);

// Ejercicio 5: Calcula la suma y el promedio de cada fila y columna en una matriz de números aleatorios. (IMPLEMENTADO)
public record CalcularEstadisticasMatrizRequest(int[][] Matriz);
public record EstadisticasFilasColumnas(
    int[] SumaPorFila,
    double[] PromedioPorFila,
    int[] SumaPorColumna,
    double[] PromedioPorColumna
);
public record CalcularEstadisticasMatrizResponse(EstadisticasFilasColumnas Estadisticas);

// Ejercicio 6: Analiza una matriz de ventas para encontrar la venta mínima, máxima, total y por día. (IMPLEMENTADO)
public record AnalizarVentasRequest(int[][] Ventas);
public record VentaInfo(int Valor, int Mes, int Dia);
public record AnalizarVentasResponse(VentaInfo VentaMinima, VentaInfo VentaMaxima, int VentaTotal, int[] VentaPorDia);

// Ejercicio 7: Realiza un análisis estadístico de calificaciones de alumnos. (IMPLEMENTADO)
public record AnalizarCalificacionesRequest(double[][] Calificaciones);
public record AnalizarCalificacionesResponse(
    double[] PromedioPorAlumno,
    double PromedioMasAlto,
    double PromedioMasBajo,
    int ParcialesReprobados,
    Dictionary<string, int> DistribucionCalificaciones
);