namespace Notas.Logica;

/// <summary>
/// Datos agregados de un curso.
/// </summary>
/// <param name="Curso">Nombre del curso.</param>
/// <param name="Alumnos">Número de alumnos.</param>
/// <param name="Media">Media de las medias de sus alumnos, con dos decimales.</param>
/// <param name="Aprobados">Número de alumnos con media de 5 o más.</param>
public record ResumenCurso(string Curso, int Alumnos, double Media, int Aprobados);
