namespace Contactos.Logica;

/// <summary>
/// Un objeto que se identifica por una clave de texto única.
/// </summary>
public interface IConClave
{
    /// <summary>Clave que identifica al objeto. Dos objetos con la misma clave son el mismo.</summary>
    string Clave { get; }
}
