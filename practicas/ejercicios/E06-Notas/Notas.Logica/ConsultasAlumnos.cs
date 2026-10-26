namespace Notas.Logica;

/// <summary>
/// Consultas sobre una colección de alumnos. Ninguna modifica la colección original.
/// </summary>
/// <param name="alumnos">Alumnos sobre los que se consulta.</param>
public class ConsultasAlumnos(IEnumerable<Alumno> alumnos)
{
    /// <summary>
    /// Alumnos aprobados, ordenados por nombre.
    /// </summary>
    /// <returns>Los alumnos con media de 5 o más.</returns>
    public List<Alumno> Aprobados()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Los mejores alumnos por media; si empatan, por orden alfabético.
    /// </summary>
    /// <param name="cantidad">Cuántos alumnos se devuelven.</param>
    /// <returns>Como mucho <paramref name="cantidad"/> alumnos.</returns>
    public List<Alumno> Mejores(int cantidad)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Busca alumnos cuyo nombre contenga un texto, sin distinguir mayúsculas.
    /// </summary>
    /// <param name="texto">Texto que se busca.</param>
    /// <returns>Los nombres que lo contienen, en orden alfabético.</returns>
    public List<string> BuscarPorNombre(string texto)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Resumen de cada curso, ordenado por nombre del curso.
    /// </summary>
    /// <returns>Un <see cref="ResumenCurso"/> por curso.</returns>
    public List<ResumenCurso> ResumenPorCurso()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Nota media de todos los alumnos.
    /// </summary>
    /// <returns>La media de las medias, con dos decimales, o 0 si no hay alumnos.</returns>
    public double MediaGeneral()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Indica si algún alumno tiene alguna nota menor que <paramref name="nota"/>.
    /// </summary>
    /// <param name="nota">Nota de referencia.</param>
    /// <returns><see langword="true"/> si hay al menos una nota por debajo.</returns>
    public bool HayNotasPorDebajoDe(double nota)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Alumnos menores de edad de un curso.
    /// </summary>
    /// <param name="curso">Curso, sin distinguir mayúsculas.</param>
    /// <returns>Nombres y edades de los alumnos menores de 18 años.</returns>
    public List<(string Nombre, int Edad)> MenoresDeEdad(string curso)
    {
        throw new NotImplementedException();
    }
}
