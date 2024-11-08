public class Producto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }

    public Producto(string nombre, double precio)
    {
        Nombre = nombre;
        Precio = precio;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Producto: {Nombre}, Precio: {Precio}");
    }

    // Sobrescribir el método ToString()
    public override string ToString()
    {
        return $"Producto: {Nombre}, Precio: {Precio}";
    }
}