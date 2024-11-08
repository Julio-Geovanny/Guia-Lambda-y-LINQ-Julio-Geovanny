using System;

namespace GuiaLambdaLinq
{
    class Program
    {
        public static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Console.WriteLine("Bienvenidos al sistema de gestión de inventario");

            // ingreso de productos por el usuario
            Console.WriteLine("¿Cuántos productos desea ingresar?");
            int cantidad = LeerCantidadProductos();

            // se ocupa el ciclo for para pedir exactamente la cantidad de productos que desea ingresar el usuario
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\nProducto {i + 1}: ");
                string nombre = LeerNombre();
                double precio = LeerPrecio();

                Producto producto = new Producto(nombre, precio);
                inventario.AgregarProducto(producto);
            }

            // ingresar el precio mínimo para el filtro
            Console.WriteLine("\nIngrese el precio mínimo para filtrar los productos: ");
            double precioMinimo = LeerPrecio();

            // filtrar y mostrar producto
            var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);

            Console.WriteLine("\nProductos filtrados y ordenados: ");
            foreach (var producto in productosFiltrados)
            {
                Console.WriteLine(producto);
            }

            // Actualizar precio de un producto
            if (LeerConfirmacion("\n¿Desea actualizar el precio de un producto? (s/n)"))
            {
                string nombreProducto = LeerNombre();
                double nuevoPrecio = LeerPrecio();
                inventario.ActualizarPrecio(nombreProducto, nuevoPrecio);
            }

            // Eliminar un producto
            if (LeerConfirmacion("\n¿Desea eliminar un producto? (s/n)"))
            {
                string nombreProducto = LeerNombre();
                inventario.EliminarProducto(nombreProducto);
            }

            // Contar y agrupar productos
            inventario.ContarProductosPorRango();

            // Generar reporte resumido del inventario
            inventario.GenerarReporte();
        }

        private static double LeerPrecio()
        {
            double precio;
            while (true)
            {
                Console.WriteLine("Precio: ");
                if (double.TryParse(Console.ReadLine(), out precio) && precio > 0)
                    return precio;
                else
                    Console.WriteLine("¡Ups! Por favor, ingrese un precio válido (número positivo).");
            }
        }

        private static string LeerNombre()
        {
            string nombre;
            while (true)
            {
                Console.WriteLine("Nombre: ");
                nombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nombre))
                    return nombre;
                else
                    Console.WriteLine("¡Atención! El nombre no puede estar vacío. Inténtelo nuevamente.");
            }
        }

        private static int LeerCantidadProductos()
        {
            int cantidad;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad > 0)
                    return cantidad;
                else
                    Console.WriteLine("¡Error! Debe ingresar un número entero positivo para la cantidad de productos.");
            }
        }

        private static bool LeerConfirmacion(string mensaje)
        {
            string respuesta;
            while (true)
            {
                Console.Write(mensaje);
                respuesta = Console.ReadLine().ToLower();
                if (respuesta == "s" || respuesta == "n")
                    return respuesta == "s";
                else
                    Console.WriteLine("Por favor, ingrese 's' para sí o 'n' para no.");
            }
        }
    }
}