using System;

namespace GuiaLambdaLinq
{
    class Program
    {
        public static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Console.WriteLine("Bienvenidos al sistema de gestion de inventario");

            // ingreso de productos por el usuario
            Console.WriteLine("Cuantos productos desea ingresar");
            int cantidad = int.Parse(Console.ReadLine());

            // se ocupa el ciclo for para pedir exactamente la cantidad de productos que desea ingresar el usuario
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\nProducto {i + 1}: ");
                Console.WriteLine("Nombre: ");
                string nombre = Console.ReadLine();

                Console.WriteLine("Precio: ");
                double precio = double.Parse(Console.ReadLine());

                Producto producto = new Producto(nombre, precio);
                inventario.AgregarProducto(producto);
            }

            // ingresar el precio minimo para el filtro
            Console.WriteLine("\nIngrese el precio minimo para filtrar los productos: ");
            double precioMinimo = double.Parse(Console.ReadLine());

            // filtrar y mostrar producto
            var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);

            Console.WriteLine("\nProductos filtrados y ordenados: ");
            foreach (var producto in productosFiltrados)
            {
                Console.WriteLine(producto);
            }

            // Actualizar precio de un producto
            Console.WriteLine("\n¿Desea actualizar el precio de un producto? (s/n)");
            if (Console.ReadLine().ToLower() == "s")
            {
                string nombreProducto = LeerNombre();
                double nuevoPrecio = LeerPrecio();
                inventario.ActualizarPrecio(nombreProducto, nuevoPrecio);
            }

        }
    }
}