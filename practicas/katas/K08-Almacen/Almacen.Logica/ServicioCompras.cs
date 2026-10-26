namespace Almacen.Logica;

/// <summary>
/// Suscriptor que apunta los productos que hay que pedir al proveedor cuando tienen el stock bajo.
/// </summary>
public class ServicioCompras
{
    /// <summary>Productos pendientes de pedir, sin repetir, en el orden en que se apuntaron.</summary>
    public IReadOnlyList<string> Pedidos => throw new NotImplementedException();

    /// <summary>
    /// Empieza a escuchar el aviso de stock bajo de un almacén.
    /// </summary>
    /// <param name="almacen">El almacén.</param>
    public void Vigilar(ControlStock almacen) => throw new NotImplementedException();

    /// <summary>
    /// Quita un producto de los pendientes cuando llega el pedido.
    /// </summary>
    /// <param name="producto">Nombre del producto.</param>
    /// <returns><see langword="true"/> si estaba pendiente.</returns>
    public bool Recibir(string producto) => throw new NotImplementedException();
}
