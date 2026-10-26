namespace Nube.Logica;

/// <summary>
/// Un archivo del que se puede mostrar una vista previa en texto.
/// </summary>
public interface IPrevisualizable
{
    /// <summary>
    /// Devuelve una descripción breve del contenido del archivo.
    /// </summary>
    /// <returns>Por ejemplo, «12 páginas» o «1920×1080 px».</returns>
    string Previsualizar();
}
