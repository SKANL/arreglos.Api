using System.ComponentModel.DataAnnotations;

namespace arreglos.Api.Attributes;

/// <summary>
/// Atributo de validación que verifica que un valor numérico sea positivo (mayor que cero).
/// Especialmente útil para validar tamaños de matrices y dimensiones.
/// </summary>
public class MustBePositiveAttribute : ValidationAttribute
{
    private readonly int _minimumValue;

    /// <summary>
    /// Inicializa una nueva instancia del atributo MustBePositive.
    /// </summary>
    /// <param name="minimumValue">Valor mínimo permitido (por defecto: 1)</param>
    public MustBePositiveAttribute(int minimumValue = 1)
    {
        _minimumValue = minimumValue;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        // Verificar si el valor es nulo
        if (value == null)
        {
            return new ValidationResult($"El campo {validationContext.DisplayName ?? validationContext.MemberName} es requerido.");
        }

        // Manejar diferentes tipos numéricos
        bool isValid = value switch
        {
            int intValue => intValue >= _minimumValue,
            long longValue => longValue >= _minimumValue,
            short shortValue => shortValue >= _minimumValue,
            byte byteValue => byteValue >= _minimumValue,
            _ => false
        };

        if (!isValid)
        {
            string fieldName = validationContext.DisplayName ?? validationContext.MemberName ?? "El valor";
            
            // Mensaje específico para matrices
            if (fieldName.ToLower().Contains("size") || fieldName.ToLower().Contains("tamaño"))
            {
                return new ValidationResult($"El tamaño de la matriz debe ser mayor o igual a {_minimumValue}.");
            }
            
            // Mensaje genérico
            return new ValidationResult($"{fieldName} debe ser mayor o igual a {_minimumValue}.");
        }

        return ValidationResult.Success;
    }

    public override string FormatErrorMessage(string name)
    {
        return $"El campo {name} debe ser un número positivo mayor o igual a {_minimumValue}.";
    }
}