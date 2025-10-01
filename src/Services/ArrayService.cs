using arreglos.Api.Services.Contracts;
using arreglos.Api.Models.Dtos;

namespace arreglos.Api.Services;

public class ArrayService : IArrayService
{
    // Ejercicio 1: Contador de ceros en cada fila de una matriz. (IMPLEMENTADO)
    public int[] ContarCerosPorFila(int[][] matriz)
    {
        // 1. Validar que la matriz no sea nula y no esté vacía.
        if (matriz == null || matriz.Length == 0)
            throw new ArgumentException("La matriz no puede ser nula o vacía.");

        // 2. Inicializar el array de resultados con el tamaño igual al número de filas.
        int[] cerosPorFila = new int[matriz.Length];

        // 3. Recorrer cada fila de la matriz.
        for (int i = 0; i < matriz.Length; i++)
        {
            // Validar que la fila no sea nula.
            if (matriz[i] == null)
                throw new ArgumentException($"La fila {i} de la matriz no puede ser nula.");

            // 4. Contar los ceros en la fila actual.
            int contadorCeros = 0;
            for (int j = 0; j < matriz[i].Length; j++)
            {
                if (matriz[i][j] == 0)
                    contadorCeros++;
            }

            // 5. Almacenar el resultado en el array de resultados.
            cerosPorFila[i] = contadorCeros;
        }

        return cerosPorFila;
    }

    // Ejercicio 2: Determina si una matriz es un cuadrado mágico y calcula su constante. (Implementado)
    public bool EsCuadradoMagico(int[][] matriz, out int constante)
    {
        constante = 0;

        // 1. Validar que la matriz no sea nula y sea cuadrada.
        if (matriz == null || matriz.Length == 0) return false;
        int n = matriz.Length;
        foreach (var fila in matriz)
        {
            if (fila.Length != n) return false; // No es cuadrada
        }

        // 1.5. Validar que todos los elementos sean positivos.
        foreach (var fila in matriz)
        {
            foreach (var elemento in fila)
            {
                if (elemento <= 0) return false; // Los elementos deben ser positivos.
            }
        }

        // 2. Calcular la constante mágica candidata (la suma de la primera fila).
        int sumaReferencia = 0;
        for (int j = 0; j < n; j++)
        {
            sumaReferencia += matriz[0][j];
        }

        // 3. Verificar las sumas de las filas restantes.
        for (int i = 1; i < n; i++)
        {
            if (matriz[i].Sum() != sumaReferencia) return false;
        }

        // 4. Verificar las sumas de las columnas.
        for (int j = 0; j < n; j++)
        {
            int sumaColumna = 0;
            for (int i = 0; i < n; i++)
            {
                sumaColumna += matriz[i][j];
            }
            if (sumaColumna != sumaReferencia) return false;
        }

        // 5. Verificar las sumas de las diagonales.
        int sumaDiagonalPrincipal = Enumerable.Range(0, n).Sum(i => matriz[i][i]);
        int sumaDiagonalSecundaria = Enumerable.Range(0, n).Sum(i => matriz[i][n - 1 - i]);
        if (sumaDiagonalPrincipal != sumaReferencia || sumaDiagonalSecundaria != sumaReferencia)
            return false;

        // 6. Si todas las sumas coinciden, es un cuadrado mágico.
        constante = sumaReferencia;
        return true;
    }

    // Ejercicio 3: Realiza operaciones aritméticas (suma, resta, producto, división) entre dos matrices. (Implementado)
    public OperacionesMatricesResponse RealizarOperacionesMatrices(int[][] matrizA, int[][] matrizB)
    {
        // 1. Validar que las matrices no sean nulas y tengan las mismas dimensiones.
        if (matrizA == null || matrizB == null || matrizA.Length == 0 || matrizB.Length == 0)
            throw new ArgumentException("Las matrices no pueden ser nulas o vacías.");

        int filas = matrizA.Length;
        int columnas = matrizA[0].Length;

        if (filas != matrizB.Length || columnas != matrizB[0].Length)
            throw new ArgumentException("Las matrices deben tener las mismas dimensiones para realizar operaciones.");

        // 2. Inicializar las matrices de resultado.
        var suma = new int[filas][];
        var resta = new int[filas][];
        var producto = new int[filas][];
        var division = new double[filas][];

        // 3. Recorrer las matrices y realizar las operaciones elemento por elemento.
        for (int i = 0; i < filas; i++)
        {
            // Validar que las filas internas tengan la misma longitud.
            if (matrizA[i].Length != columnas || matrizB[i].Length != columnas)
                throw new ArgumentException("Todas las filas de las matrices deben tener la misma cantidad de columnas.");

            suma[i] = new int[columnas];
            resta[i] = new int[columnas];
            producto[i] = new int[columnas];
            division[i] = new double[columnas];

            for (int j = 0; j < columnas; j++)
            {
                suma[i][j] = matrizA[i][j] + matrizB[i][j];
                resta[i][j] = matrizA[i][j] - matrizB[i][j];
                producto[i][j] = matrizA[i][j] * matrizB[i][j];

                // Manejo de la división por cero.
                if (matrizB[i][j] == 0)
                {
                    // El resultado de dividir por cero en punto flotante es Infinito o NaN.
                    division[i][j] = double.PositiveInfinity; 
                }
                else
                {
                    division[i][j] = (double)matrizA[i][j] / matrizB[i][j];
                }
            }
        }

        return new OperacionesMatricesResponse(suma, resta, producto, division);
    }

    // Ejercicio 4: Genera una matriz identidad (diagonal de 1s, resto 0s) de un tamaño N. (YA IMPLEMENTADO)
    public int[][] GenerarMatrizIdentidad(int size)
    {
        // La validación en el DTO ([MustBePositive]) ya previene que size sea <= 0.
        // Esta validación aquí es una capa extra de seguridad si el servicio se llamara desde otro lugar.
        if (size <= 0)
            throw new ArgumentException("El tamaño debe ser mayor que 0", nameof(size));

        // Inicializa la matriz escalonada (array de arrays).
        int[][] matriz = new int[size][];
        for (int i = 0; i < size; i++)
        {
            matriz[i] = new int[size];
            // Asigna el 1 en la diagonal principal directamente al crear la fila.
            // El resto de los elementos del array de enteros se inicializan a 0 por defecto.
            matriz[i][i] = 1;
        }

        return matriz;
    }
    // Ejercicio 5: Calcula la suma y el promedio de cada fila y columna en una matriz de números aleatorios. (IMPLEMENTADO)
    public EstadisticasFilasColumnas CalcularEstadisticasMatriz(int[][] matriz)
    {
        // 1. Validar que la matriz no sea nula y no esté vacía.
        if (matriz == null || matriz.Length == 0)
            throw new ArgumentException("La matriz no puede ser nula o vacía.");

        int filas = matriz.Length;
        
        // Validar que todas las filas tengan al menos un elemento y la misma longitud.
        int columnas = matriz[0]?.Length ?? 0;
        if (columnas == 0)
            throw new ArgumentException("La matriz debe tener al menos una columna.");

        // 2. Inicializar los arrays de resultados.
        int[] sumaPorFila = new int[filas];
        double[] promedioPorFila = new double[filas];
        int[] sumaPorColumna = new int[columnas];
        double[] promedioPorColumna = new double[columnas];

        // 3. Calcular suma y promedio por fila.
        for (int i = 0; i < filas; i++)
        {
            // Validar que la fila no sea nula y tenga la misma cantidad de columnas.
            if (matriz[i] == null)
                throw new ArgumentException($"La fila {i} no puede ser nula.");
            
            if (matriz[i].Length != columnas)
                throw new ArgumentException("Todas las filas deben tener la misma cantidad de columnas.");

            int sumaFila = 0;
            for (int j = 0; j < columnas; j++)
            {
                sumaFila += matriz[i][j];
            }
            
            sumaPorFila[i] = sumaFila;
            promedioPorFila[i] = (double)sumaFila / columnas;
        }

        // 4. Calcular suma y promedio por columna.
        for (int j = 0; j < columnas; j++)
        {
            int sumaColumna = 0;
            for (int i = 0; i < filas; i++)
            {
                sumaColumna += matriz[i][j];
            }
            
            sumaPorColumna[j] = sumaColumna;
            promedioPorColumna[j] = (double)sumaColumna / filas;
        }

        return new EstadisticasFilasColumnas(
            sumaPorFila,
            promedioPorFila,
            sumaPorColumna,
            promedioPorColumna
        );
    }

    // Ejercicio 6: Analiza una matriz de ventas para encontrar la venta mínima, máxima, total y por día. (IMPLEMENTADO)
    public AnalizarVentasResponse AnalizarVentas(int[][] ventas)
    {
        if (ventas == null || ventas.Length == 0 || ventas[0].Length == 0)
            throw new ArgumentException("La matriz de ventas no puede ser nula o vacía.");

        int meses = ventas.Length;
        int dias = ventas[0].Length;

        var ventaMinima = new VentaInfo(ventas[0][0], 1, 1);
        var ventaMaxima = new VentaInfo(ventas[0][0], 1, 1);
        int ventaTotal = 0;
        var ventaPorDia = new int[dias];

        for (int i = 0; i < meses; i++)
        {
            for (int j = 0; j < dias; j++)
            {
                int ventaActual = ventas[i][j];

                // Actualizar venta mínima
                if (ventaActual < ventaMinima.Valor)
                    ventaMinima = new VentaInfo(ventaActual, i + 1, j + 1);

                // Actualizar venta máxima
                if (ventaActual > ventaMaxima.Valor)
                    ventaMaxima = new VentaInfo(ventaActual, i + 1, j + 1);

                ventaTotal += ventaActual;
                ventaPorDia[j] += ventaActual;
            }
        }

        return new AnalizarVentasResponse(ventaMinima, ventaMaxima, ventaTotal, ventaPorDia);
    }

    // Ejercicio 7: Realiza un análisis estadístico de calificaciones de alumnos. (IMPLEMENTADO)
    public AnalizarCalificacionesResponse AnalizarCalificaciones(double[][] calificaciones)
    {
        if (calificaciones == null || calificaciones.Length == 0 || calificaciones[0].Length == 0)
            throw new ArgumentException("La matriz de calificaciones no puede ser nula o vacía.");

        int alumnos = calificaciones.Length;

        var promedios = calificaciones.Select(fila => fila.Average()).ToArray();
        double promedioMasAlto = promedios.Max();
        double promedioMasBajo = promedios.Min();

        int parcialesReprobados = calificaciones.SelectMany(fila => fila).Count(calif => calif < 7.0);

        var distribucion = new Dictionary<string, int>
        {
            { "0-4.9", 0 }, { "5.0-5.9", 0 }, { "6.0-6.9", 0 }, { "7.0-7.9", 0 },
            { "8.0-8.9", 0 }, { "9.0-10", 0 }
        };

        foreach (var p in promedios)
        {
            if (p < 5.0) distribucion["0-4.9"]++;
            else if (p < 6.0) distribucion["5.0-5.9"]++;
            else if (p < 7.0) distribucion["6.0-6.9"]++;
            else if (p < 8.0) distribucion["7.0-7.9"]++;
            else if (p < 9.0) distribucion["8.0-8.9"]++;
            else distribucion["9.0-10"]++;
        }

        return new AnalizarCalificacionesResponse(
            promedios,
            promedioMasAlto,
            promedioMasBajo,
            parcialesReprobados,
            distribucion
        );
    }
}