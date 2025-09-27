using arreglos.Api.Attributes;

namespace arreglos.Api.Models.Dtos;

// Ejercicio 1: Contador de ceros en cada fila de una matriz. (NO IMPLEMENTADO)
// Ejercicio 2: Determina si una matriz es un cuadrado mágico y calcula su constante. (NO IMPLEMENTADO)
// Ejercicio 3: Realiza operaciones aritméticas (suma, resta, producto, división) entre dos matrices. (NO IMPLEMENTADO)

// Ejercicio 4: Genera una matriz identidad (diagonal de 1s, resto 0s) de un tamaño N. (YA IMPLEMENTADO)
public record GenerarMatrizIdentidadRequest( [MustBePositive] int Size );
public record GenerarMatrizIdentidadResponse(int[][] Matriz);

// Ejercicio 5: Calcula la suma y el promedio de cada fila y columna en una matriz de números aleatorios. (NO IMPLEMENTADO)
// Ejercicio 6: Analiza una matriz de ventas para encontrar la venta mínima, máxima, total y por día. (NO IMPLEMENTADO)
// Ejercicio 7: Realiza un análisis estadístico de calificaciones de alumnos. (NO IMPLEMENTADO)