namespace Almacen.Logica;

/// <summary>
/// Controla las unidades de los productos de un almacén y avisa cuando un producto baja del stock mínimo o se agota.
/// </summary>
/// <example>
/// <code>
/// var almacen = new ControlStock(5);
/// almacen.StockBajo += (sender, e) => Console.WriteLine($"Quedan {e.Unidades} de {e.Producto}");
/// almacen.Entrada("Tornillos", 8);
/// almacen.Salida("Tornillos", 4); // Quedan 4 de Tornillos
/// </code>
/// </example>
public class ControlStock
{
    /// <summary>
    /// Crea un almacén vacío.
    /// </summary>
    /// <param name="stockMinimo">Por debajo de estas unidades, un producto tiene el stock bajo. No puede ser negativo.</param>
    /// <exception cref="ArgumentOutOfRangeException">Si el stock mínimo es negativo.</exception>
    public ControlStock(int stockMinimo)
    {
        throw new NotImplementedException();
    }

    /// <summary>Se lanza cuando una salida deja un producto por debajo del stock mínimo, si antes no lo estaba.</summary>
    public event EventHandler<StockEventArgs>? StockBajo;

    /// <summary>Se lanza cuando una salida deja un producto a 0 unidades.</summary>
    public event EventHandler<StockEventArgs>? ProductoAgotado;

    /// <summary>Por debajo de estas unidades, un producto tiene el stock bajo.</summary>
    public int StockMinimo => throw new NotImplementedException();

    /// <summary>
    /// Unidades de un producto.
    /// </summary>
    /// <param name="producto">Nombre del producto.</param>
    /// <returns>Las unidades, o 0 si el producto no está en el almacén.</returns>
    public int Unidades(string producto) => throw new NotImplementedException();

    /// <summary>
    /// Añade unidades de un producto (si no estaba, lo da de alta).
    /// </summary>
    /// <param name="producto">Nombre del producto.</param>
    /// <param name="unidades">Unidades que entran. Mayor que 0.</param>
    /// <exception cref="ArgumentOutOfRangeException">Si las unidades no son mayores que 0.</exception>
    public void Entrada(string producto, int unidades)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Saca unidades de un producto y lanza los avisos que correspondan: primero <see cref="StockBajo"/> y después <see cref="ProductoAgotado"/>.
    /// </summary>
    /// <param name="producto">Nombre del producto.</param>
    /// <param name="unidades">Unidades que salen. Mayor que 0.</param>
    /// <exception cref="ArgumentOutOfRangeException">Si las unidades no son mayores que 0.</exception>
    /// <exception cref="InvalidOperationException">Si no hay unidades suficientes (y entonces no cambia nada).</exception>
    public void Salida(string producto, int unidades)
    {
        throw new NotImplementedException();
    }
}
