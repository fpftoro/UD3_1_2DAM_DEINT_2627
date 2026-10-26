using System.Text;

namespace Cine.Logica;

/// <summary>
/// Sala de cine con una matriz de asientos que se pueden reservar y cancelar.
/// </summary>
public class SalaCine
{
    /// <summary>
    /// Crea una sala con todos los asientos libres.
    /// </summary>
    /// <param name="filas">Número de filas, de 1 a 26 (A–Z). Por defecto, 5.</param>
    /// <param name="columnas">Número de asientos por fila, de 1 a 30. Por defecto, 8.</param>
    /// <exception cref="ArgumentOutOfRangeException">Si las dimensiones no son válidas.</exception>
    public SalaCine(int filas = 5, int columnas = 8)
    {
        throw new NotImplementedException();
    }

    /// <summary>Se lanza después de reservar uno o varios asientos.</summary>
    public event EventHandler<AsientosEventArgs>? AsientosReservados;

    /// <summary>Se lanza después de cancelar la reserva de un asiento.</summary>
    public event EventHandler<AsientosEventArgs>? ReservaCancelada;

    /// <summary>Número de filas.</summary>
    public int Filas => throw new NotImplementedException();

    /// <summary>Número de asientos por fila.</summary>
    public int Columnas => throw new NotImplementedException();

    /// <summary>Número de asientos libres.</summary>
    public int Libres
    {
        get => throw new NotImplementedException();
    }

    /// <summary>
    /// Convierte un código como «C5» en su fila y columna.
    /// </summary>
    /// <param name="codigo">Letra de la fila (mayúscula o minúscula) seguida del número de columna.</param>
    /// <param name="fila">Fila, empezando en 1, si el código tiene el formato correcto.</param>
    /// <param name="columna">Columna, empezando en 1, si el código tiene el formato correcto.</param>
    /// <returns><see langword="true"/> si el código tiene el formato correcto (no comprueba que exista en la sala).</returns>
    public static bool TryParseCodigo(string? codigo, out int fila, out int columna)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Devuelve un asiento.
    /// </summary>
    /// <param name="fila">Fila, empezando en 1.</param>
    /// <param name="columna">Columna, empezando en 1.</param>
    /// <returns>El asiento.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Si el asiento no existe en la sala.</exception>
    public Asiento ObtenerAsiento(int fila, int columna)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Reserva un asiento si está libre.
    /// </summary>
    /// <param name="fila">Fila, empezando en 1.</param>
    /// <param name="columna">Columna, empezando en 1.</param>
    /// <returns><see langword="true"/> si se ha reservado; <see langword="false"/> si ya estaba reservado.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Si el asiento no existe en la sala.</exception>
    public bool Reservar(int fila, int columna)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Cancela la reserva de un asiento.
    /// </summary>
    /// <param name="fila">Fila, empezando en 1.</param>
    /// <param name="columna">Columna, empezando en 1.</param>
    /// <returns><see langword="true"/> si se ha cancelado; <see langword="false"/> si no estaba reservado.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Si el asiento no existe en la sala.</exception>
    public bool Cancelar(int fila, int columna)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Reserva asientos seguidos en la misma fila para un grupo, empezando a buscar por la fila A.
    /// </summary>
    /// <param name="cantidad">Número de asientos, de 1 al número de columnas.</param>
    /// <returns>Los asientos reservados, o <see langword="null"/> si no hay ningún hueco suficiente.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Si la cantidad no es válida.</exception>
    public IReadOnlyList<Asiento>? ReservarGrupo(int cantidad)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Dibuja la sala en texto: ○ libre y ● reservado, con la pantalla arriba.
    /// </summary>
    /// <returns>Una línea por fila, precedida de los números de columna.</returns>
    public string Mapa()
    {
        throw new NotImplementedException();
    }
}
