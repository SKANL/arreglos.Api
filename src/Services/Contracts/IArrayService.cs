using arreglos.Api.Models.Dtos;

namespace arreglos.Api.Services.Contracts;

public interface IArrayService
{
    int[][] GenerarMatrizIdentidad(int size);
    bool EsCuadradoMagico(int[][] matriz, out int constante);
    OperacionesMatricesResponse RealizarOperacionesMatrices(int[][] matrizA, int[][] matrizB);
}