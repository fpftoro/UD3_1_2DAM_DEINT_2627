using System.Text.Json;

namespace Notas.Logica;

/// <summary>
/// Lee alumnos en formato JSON.
/// </summary>
public static class CargadorAlumnos
{
    /// <summary>
    /// Convierte un texto JSON con una lista de alumnos.
    /// </summary>
    /// <param name="json">Texto con un array JSON de alumnos.</param>
    /// <returns>La lista de alumnos (vacía si el JSON es <c>null</c>).</returns>
    /// <exception cref="JsonException">Si el texto no es un JSON válido.</exception>
    public static List<Alumno> DesdeTexto(string json)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Lee un fichero JSON con una lista de alumnos.
    /// </summary>
    /// <param name="ruta">Ruta del fichero.</param>
    /// <returns>La lista de alumnos.</returns>
    /// <exception cref="FileNotFoundException">Si el fichero no existe.</exception>
    public static List<Alumno> DesdeFichero(string ruta)
    {
        throw new NotImplementedException();
    }
}
