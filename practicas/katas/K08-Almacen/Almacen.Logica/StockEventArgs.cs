namespace Almacen.Logica;

/// <summary>
/// Datos de los eventos del <see cref="ControlStock"/>: el producto, sus unidades y el stock mínimo.
/// </summary>
/// <param name="producto">Nombre del producto.</param>
/// <param name="unidades">Unidades que quedan.</param>
/// <param name="minimo">Stock mínimo del almacén.</param>
public class StockEventArgs(string producto, int unidades, int minimo) : EventArgs
{
    /// <summary>Nombre del producto.</summary>
    public string Producto { get; } = producto;

    /// <summary>Unidades que quedan.</summary>
    public int Unidades { get; } = unidades;

    /// <summary>Stock mínimo del almacén.</summary>
    public int Minimo { get; } = minimo;
}
