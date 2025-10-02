using System;
using System.Collections.Generic;

namespace arreglos.Api.Services;

/// <summary>
/// Clase responsable de aplanar matrices jagged (int[][]) usando recursión
/// y calcular estadísticas básicas (suma, min, max, promedio).
/// </summary>
public class ArrayAnalyzer
{
    private readonly List<int> _values = new();

    public int[] Flattened => _values.ToArray();
    public long Sum => _values.Count == 0 ? 0 : _values.Sum();
    public int Min => _values.Count == 0 ? 0 : _values.Min();
    public int Max => _values.Count == 0 ? 0 : _values.Max();
    public double Average => _values.Count == 0 ? 0 : _values.Average();

    // Expone un método público para aplanar la matriz recursivamente.
    public void Flatten(int[][] matrix)
    {
        if (matrix == null) throw new ArgumentNullException(nameof(matrix));
        _values.Clear();
        FlattenMatrix(matrix, 0);
    }

    private void FlattenMatrix(int[][] matrix, int rowIndex)
    {
        if (rowIndex >= matrix.Length) return;
        var row = matrix[rowIndex];
        if (row != null)
        {
            FlattenRow(row, 0);
        }
        FlattenMatrix(matrix, rowIndex + 1);
    }

    private void FlattenRow(int[] row, int colIndex)
    {
        if (row == null) return;
        if (colIndex >= row.Length) return;
        _values.Add(row[colIndex]);
        FlattenRow(row, colIndex + 1);
    }
}
