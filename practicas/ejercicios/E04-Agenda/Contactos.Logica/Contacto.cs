namespace Contactos.Logica;

/// <summary>
/// Contacto de la agenda. Dos contactos son iguales si tienen el mismo nombre,
/// sin distinguir mayúsculas de minúsculas, aunque su teléfono sea distinto.
/// </summary>
public class Contacto : IConClave, IEquatable<Contacto>, IComparable<Contacto>
{
    /// <summary>
    /// Crea un contacto.
    /// </summary>
    /// <param name="nombre">Nombre del contacto. No puede estar vacío.</param>
    /// <param name="telefono">Teléfono. No se valida su formato.</param>
    /// <exception cref="ArgumentException">Si el nombre está vacío.</exception>
    public Contacto(string nombre, string telefono)
    {
        throw new NotImplementedException();
    }

    /// <summary>Nombre del contacto.</summary>
    public string Nombre { get; }

    /// <summary>Teléfono del contacto. Se puede cambiar.</summary>
    public string Telefono { get; set; }

    /// <summary>La clave del contacto es su nombre.</summary>
    public string Clave => throw new NotImplementedException();

    /// <summary>
    /// Compara dos contactos por su nombre, sin distinguir mayúsculas de minúsculas.
    /// </summary>
    /// <param name="other">Contacto con que se compara.</param>
    /// <returns><see langword="true"/> si tienen el mismo nombre.</returns>
    public bool Equals(Contacto? other)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Código hash coherente con <see cref="Equals(Contacto?)"/>: el mismo para nombres iguales.
    /// </summary>
    /// <returns>El código hash del nombre sin distinguir mayúsculas.</returns>
    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Ordena los contactos alfabéticamente por nombre.
    /// </summary>
    /// <param name="other">Contacto con que se compara.</param>
    /// <returns>Negativo si este va antes, cero si van igual, positivo si va después.</returns>
    public int CompareTo(Contacto? other)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Devuelve el contacto en una línea.
    /// </summary>
    /// <returns>Nombre y teléfono, por ejemplo <c>Ana López · 600 111 222</c>.</returns>
    public override string ToString()
    {
        throw new NotImplementedException();
    }
}
