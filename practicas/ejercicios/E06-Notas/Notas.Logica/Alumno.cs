namespace Notas.Logica;

/// <summary>
/// Alumno con sus notas de evaluación.
/// </summary>
/// <param name="Nombre">Nombre completo.</param>
/// <param name="Curso">Curso al que pertenece (por ejemplo, «2DAM»).</param>
/// <param name="Edad">Edad en años.</param>
/// <param name="Notas">Notas de 0 a 10.</param>
public record Alumno(string Nombre, string Curso, int Edad, List<double> Notas)
{
    /// <summary>Media de las notas redondeada a dos decimales, o 0 si no tiene notas.</summary>
    public double Media => throw new NotImplementedException();

    /// <summary>Indica si la media es de 5 o más.</summary>
    public bool Aprobado => throw new NotImplementedException();
}
