namespace GestionTaller.Logica;

/// <summary>
/// Taller mecánico: coches en reparación y facturas.
/// </summary>
public class Taller
{
    /// <summary>Precio de una hora de trabajo, sin IVA.</summary>
    public const decimal PrecioHora = 45m;

    /// <summary>Porcentaje de IVA que se aplica a las facturas.</summary>
    public const int IvaPorcentaje = 21;

    private readonly List<Coche> _coches = [];

    /// <summary>Coches del taller, en orden de llegada.</summary>
    public IReadOnlyList<Coche> Coches => _coches;

    /// <summary>Coches que todavía no están reparados (pendientes o en reparación).</summary>
    public int Pendientes
    {
        get
        {
            var pendientes = 0;
            foreach (var coche in _coches)
            {
                if (coche.Estado == EstadoReparacion.Pendiente)
                {
                    pendientes++;
                }
            }

            return pendientes;
        }
    }

    /// <summary>
    /// Añade un coche si su matrícula no está ya en el taller.
    /// </summary>
    /// <param name="coche">Coche que entra.</param>
    /// <returns><see langword="true"/> si se ha añadido.</returns>
    public bool Agregar(Coche coche)
    {
        _coches.Add(coche);
        return true;
    }

    /// <summary>
    /// Busca un coche por su matrícula, se escriba como se escriba (1234bcd, 1234 BCD…).
    /// </summary>
    /// <param name="matricula">Matrícula que se busca.</param>
    /// <returns>El coche, o <see langword="null"/> si no está.</returns>
    public Coche? Buscar(string matricula)
    {
        foreach (var coche in _coches)
        {
            if (coche.Matricula == matricula)
            {
                return coche;
            }
        }

        return null;
    }

    /// <summary>
    /// Saca un coche del taller.
    /// </summary>
    /// <param name="matricula">Matrícula del coche.</param>
    /// <returns><see langword="true"/> si estaba y se ha eliminado.</returns>
    public bool Eliminar(string matricula)
    {
        var buscada = Coche.NormalizarMatricula(matricula);
        for (var i = 0; i < _coches.Count - 1; i++)
        {
            if (_coches[i].Matricula == buscada)
            {
                _coches.RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Pone un coche pendiente en reparación.
    /// </summary>
    /// <param name="matricula">Matrícula del coche.</param>
    /// <exception cref="KeyNotFoundException">Si el coche no está en el taller.</exception>
    /// <exception cref="InvalidOperationException">Si el coche no estaba pendiente.</exception>
    public void EmpezarReparacion(string matricula)
    {
        var coche = BuscarObligatorio(matricula);
        if (coche.Estado != EstadoReparacion.Pendiente)
        {
            throw new InvalidOperationException($"{coche.Matricula} no está pendiente.");
        }

        coche.Estado = EstadoReparacion.EnReparacion;
    }

    /// <summary>
    /// Termina la reparación de un coche y anota las horas de trabajo.
    /// </summary>
    /// <param name="matricula">Matrícula del coche.</param>
    /// <param name="horas">Horas de trabajo, mayores que cero.</param>
    /// <exception cref="KeyNotFoundException">Si el coche no está en el taller.</exception>
    /// <exception cref="InvalidOperationException">Si el coche no estaba en reparación.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Si las horas no son mayores que cero.</exception>
    public void Reparar(string matricula, decimal horas)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(horas);
        var coche = BuscarObligatorio(matricula);
        if (coche.Estado != EstadoReparacion.EnReparacion)
        {
            throw new InvalidOperationException($"{coche.Matricula} no está en reparación.");
        }

        coche.Horas = horas;
        coche.Estado = EstadoReparacion.Reparado;
    }

    /// <summary>
    /// Calcula la factura de un coche reparado: horas por precio, más IVA.
    /// </summary>
    /// <param name="matricula">Matrícula del coche.</param>
    /// <returns>Importe con IVA, redondeado a céntimos (0,005 sube).</returns>
    /// <exception cref="KeyNotFoundException">Si el coche no está en el taller.</exception>
    /// <exception cref="InvalidOperationException">Si el coche no está reparado.</exception>
    public decimal CalcularFactura(string matricula)
    {
        var coche = BuscarObligatorio(matricula);
        if (coche.Estado != EstadoReparacion.Reparado)
        {
            throw new InvalidOperationException($"{coche.Matricula} todavía no está reparado.");
        }

        var baseImponible = coche.Horas * PrecioHora;
        return Math.Round(baseImponible * (1 + (IvaPorcentaje / 100)), 2);
    }

    private Coche BuscarObligatorio(string matricula)
    {
        return Buscar(matricula) ?? throw new KeyNotFoundException($"No hay ningún coche con la matrícula {matricula}.");
    }
}
