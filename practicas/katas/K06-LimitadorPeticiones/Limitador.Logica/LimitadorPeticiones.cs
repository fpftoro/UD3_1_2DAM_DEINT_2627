namespace Limitador.Logica;

/// <summary>
/// Limita cuántas peticiones se aceptan en un periodo de tiempo (por ejemplo, 3 cada 10 segundos).
/// El periodo es una ventana deslizante: cada petición aceptada deja de contar cuando pasa el tiempo de la ventana.
/// </summary>
/// <example>
/// <code>
/// var limitador = new LimitadorPeticiones(2, TimeSpan.FromSeconds(10));
/// limitador.PeticionRechazada += (sender, e) => Console.WriteLine($"Espera {e.Espera.TotalSeconds} s");
/// Console.WriteLine(limitador.Intentar()); // True
/// Console.WriteLine(limitador.Intentar()); // True
/// Console.WriteLine(limitador.Intentar()); // False y avisa
/// </code>
/// </example>
public class LimitadorPeticiones
{
    /// <summary>
    /// Crea un limitador.
    /// </summary>
    /// <param name="maximo">Peticiones que se aceptan dentro de la ventana. Mayor que cero.</param>
    /// <param name="ventana">Duración de la ventana. Mayor que cero.</param>
    /// <param name="reloj">Reloj que da la hora. Si es <see langword="null"/>, el del sistema.</param>
    /// <exception cref="ArgumentOutOfRangeException">Si el máximo o la ventana no son mayores que cero.</exception>
    public LimitadorPeticiones(int maximo, TimeSpan ventana, TimeProvider? reloj = null)
    {
        throw new NotImplementedException();
    }

    /// <summary>Se lanza cada vez que se rechaza una petición.</summary>
    public event EventHandler<RechazoEventArgs>? PeticionRechazada;

    /// <summary>Peticiones que se podrían aceptar ahora mismo.</summary>
    public int Disponibles => throw new NotImplementedException();

    /// <summary>
    /// Intenta hacer una petición.
    /// </summary>
    /// <returns><see langword="true"/> si se acepta; <see langword="false"/> si se ha llegado al máximo (y lanza <see cref="PeticionRechazada"/>).</returns>
    public bool Intentar()
    {
        throw new NotImplementedException();
    }
}
