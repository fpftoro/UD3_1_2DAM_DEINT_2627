namespace GestionTaller.Logica;

/// <summary>
/// Coche que entra en el taller.
/// </summary>
public class Coche
{
    /// <summary>
    /// Registra un coche con su matrícula y su marca.
    /// </summary>
    /// <param name="matricula">Matrícula: cuatro cifras y tres letras, con o sin espacio (1234 BCD).</param>
    /// <param name="marca">Marca del coche.</param>
    /// <exception cref="ArgumentException">Si la matrícula no tiene el formato correcto o la marca está vacía.</exception>
    public Coche(string matricula, string marca)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(marca);
        Matricula = NormalizarMatricula(matricula);
        if (!EsMatriculaValida(Matricula))
        {
            throw new ArgumentException($"La matrícula «{matricula}» no tiene el formato 1234 BCD.", nameof(matricula));
        }

        Marca = marca.Trim();
    }

    /// <summary>Matrícula en mayúsculas y sin espacios (1234BCD).</summary>
    public string Matricula { get; }

    /// <summary>Marca del coche.</summary>
    public string Marca { get; }

    /// <summary>Estado de la reparación.</summary>
    public EstadoReparacion Estado { get; internal set; } = EstadoReparacion.Pendiente;

    /// <summary>Horas de trabajo de la reparación (0 hasta que se repara).</summary>
    public decimal Horas { get; internal set; }

    /// <summary>
    /// Pasa una matrícula a mayúsculas y le quita los espacios.
    /// </summary>
    /// <param name="matricula">Matrícula tal como la escribe el usuario.</param>
    /// <returns>La matrícula normalizada.</returns>
    public static string NormalizarMatricula(string matricula)
    {
        return matricula.Replace(" ", "").ToUpperInvariant();
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"{Matricula} · {Marca} · {Estado}";
    }

    private static bool EsMatriculaValida(string matricula)
    {
        if (matricula.Length != 7)
        {
            return false;
        }

        for (var i = 0; i < 4; i++)
        {
            if (!char.IsAsciiDigit(matricula[i]))
            {
                return false;
            }
        }

        for (var i = 4; i < 7; i++)
        {
            if (!char.IsAsciiLetterUpper(matricula[i]))
            {
                return false;
            }
        }

        return true;
    }
}
