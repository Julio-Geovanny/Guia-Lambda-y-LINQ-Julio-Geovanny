public class Inventario
{
    public List<Producto> Productos { get; private set; }

    public Inventario()
    {
        Productos = new List<Producto>();
    }

    public void AgregarProducto(Producto producto)
    {
        Productos.Add(producto);
    }

    public void ActualizarPrecio(string nombre, double nuevoPrecio)
    {
        var producto = Productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (producto != null)
        {
            producto.Precio = nuevoPrecio;
            Console.WriteLine($"El precio del producto '{nombre}' ha sido actualizado a {nuevoPrecio:C}.");
        }
        else
        {
            Console.WriteLine($"Producto '{nombre}' no encontrado.");
        }
    }

    public void EliminarProducto(string nombre)
    {
        var producto = Productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (producto != null)
        {
            Productos.Remove(producto);
            Console.WriteLine($"El producto '{nombre}' ha sido eliminado.");
        }
        else
        {
            Console.WriteLine($"Producto '{nombre}' no encontrado.");
        }
    }
}