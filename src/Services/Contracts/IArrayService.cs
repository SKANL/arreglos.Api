using arreglos.Api.Models.Dtos;

namespace arreglos.Api.Services.Contracts;

public interface IArrayService
{
    int[] ContarCerosPorFila(int[][] matriz);
    int[][] GenerarMatrizIdentidad(int size);
    bool EsCuadradoMagico(int[][] matriz, out int constante);
    OperacionesMatricesResponse RealizarOperacionesMatrices(int[][] matrizA, int[][] matrizB);
    EstadisticasFilasColumnas CalcularEstadisticasMatriz(int[][] matriz);
    AnalizarVentasResponse AnalizarVentas(int[][] ventas);
    AnalizarCalificacionesResponse AnalizarCalificaciones(double[][] calificaciones);

    // Ejercicio 8: Revertir un arreglo usando recursión (OOP/recursividad).
    int[] ReverseArrayRecursively(int[] array);

    // Ejercicio 9: Contar ocurrencias de un valor en un arreglo usando recursión.
    int CountOccurrencesRecursively(int[] array, int value);

    // Ejercicio 10: Aplanar una matriz jagged y calcular estadísticas usando una clase OOP y recursión.
    FlattenStatsResponse FlattenMatrixAndComputeStats(int[][] matrix);
}