using arreglos.Api.Services.Contracts;

namespace arreglos.Api.Services;

public class ArrayService : IArrayService
{
    // Ejercicio 1: Contador de ceros en cada fila de una matriz. (NO IMPLEMENTADO)
    // Ejercicio 2: Determina si una matriz es un cuadrado mágico y calcula su constante. (NO IMPLEMENTADO)
    // Ejercicio 3: Realiza operaciones aritméticas (suma, resta, producto, división) entre dos matrices. (NO IMPLEMENTADO)

    // Ejercicio 4: Genera una matriz identidad (diagonal de 1s, resto 0s) de un tamaño N. (YA IMPLEMENTADO)
    public int[][] GenerarMatrizIdentidad(int size)
    {
        if (size <= 0)
            throw new ArgumentException("El tamaño debe ser mayor que 0", nameof(size));

        int[][] matriz = new int[size][];
        for (int i = 0; i < size; i++)
        {
            matriz[i] = new int[size];
        }

        LlenarMatrizIdentidadRecursivo(matriz, 0, 0, size);
        return matriz;
    }

    private void LlenarMatrizIdentidadRecursivo(int[][] matriz, int fila, int columna, int size)
    {
        // Caso base: si hemos procesado todas las filas
        if (fila >= size)
            return;

        // Caso base: si hemos procesado todas las columnas de la fila actual
        if (columna >= size)
        {
            // Pasar a la siguiente fila
            LlenarMatrizIdentidadRecursivo(matriz, fila + 1, 0, size);
            return;
        }

        // Lógica: Si estamos en la diagonal principal (fila == columna), asignar 1, sino 0
        matriz[fila][columna] = (fila == columna) ? 1 : 0;

        // Llamada recursiva para la siguiente columna
        LlenarMatrizIdentidadRecursivo(matriz, fila, columna + 1, size);
    }

    // Ejercicio 5: Calcula la suma y el promedio de cada fila y columna en una matriz de números aleatorios. (NO IMPLEMENTADO)
    // Ejercicio 6: Analiza una matriz de ventas para encontrar la venta mínima, máxima, total y por día. (NO IMPLEMENTADO)
    // Ejercicio 7: Realiza un análisis estadístico de calificaciones de alumnos. (NO IMPLEMENTADO)
}