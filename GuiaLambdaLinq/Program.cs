﻿using System;
using System.Collections.Generic;

namespace GuiaLambdaLinq
{
    class Program
    {
        public static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Console.WriteLine("Bienvenidos al sistema de gestión de inventario");

            // Inicializar productos predeterminados
            InicializarProductos(inventario);

            // Menú principal
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("\nSeleccione una opción:");
                Console.WriteLine("1. Agregar nuevos productos");
                Console.WriteLine("2. Mostrar todos los productos");
                Console.WriteLine("3. Filtrar productos por precio");
                Console.WriteLine("4. Actualizar precio de un producto");
                Console.WriteLine("5. Eliminar un producto");
                Console.WriteLine("6. Salir");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarProductos(inventario);
                        break;
                    case "2":
                        MostrarProductos(inventario);
                        break;
                    case "3":
                        FiltrarProductosPorPrecio(inventario);
                        break;
                    case "4":
                        ActualizarPrecioProducto(inventario);
                        break;
                    case "5":
                        EliminarProducto(inventario);
                        break;
                    case "6":
                        continuar = false;
                        Console.WriteLine("¡Gracias por usar el sistema de gestión de inventario! Hasta luego.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, elija una opción del 1 al 6.");
                        break;
                }
            }
        }

        private static void InicializarProductos(Inventario inventario)
        {
            // Agregar productos predeterminados
            inventario.AgregarProducto(new Producto("ASUS TERRANEITOR", 2000));
            inventario.AgregarProducto(new Producto("OnePlus 12", 850));
            inventario.AgregarProducto(new Producto("SONY Vision", 7000));
            inventario.AgregarProducto(new Producto("Tableta RED MAGIC 9s", 900));
        }

        private static void AgregarProductos(Inventario inventario)
        {
            Console.WriteLine("¿Cuántos productos desea ingresar?");
            int cantidad = LeerCantidadProductos();

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\nProducto {i + 1}: ");
                string nombre = LeerNombre();
                double precio = LeerPrecio();

                Producto producto = new Producto(nombre, precio);
                inventario.AgregarProducto(producto);
            }
        }

        private static void MostrarProductos(Inventario inventario)
        {
            var productos = inventario.FiltrarYOrdenarProductos(0); // Muestra todos los productos
            Console.WriteLine("\nTodos los productos:");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto);
            }
        }

        private static void FiltrarProductosPorPrecio(Inventario inventario)
        {
            Console.WriteLine("\n¿Desea filtrar por:");
            Console.WriteLine("1. Menores al precio?");
            Console.WriteLine("2. Mayores al precio?");

            string opcionFiltro = Console.ReadLine();

            double precioMinimo;

            if (opcionFiltro == "1")
            {
                Console.WriteLine("Bien, ingrese el precio para el filtrado: ");
                precioMinimo = LeerPrecio();

                var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);

                Console.WriteLine("\nProductos menores al precio ingresado: ");
                foreach (var producto in productosFiltrados.Where(p => p.Precio < precioMinimo))
                {
                    Console.WriteLine(producto);
                }
            }
            else if (opcionFiltro == "2")
            {
                Console.WriteLine("Bien, ingrese el precio para el filtrado: ");
                precioMinimo = LeerPrecio();

                var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);

                Console.WriteLine("\nProductos mayores al precio ingresado: ");
                foreach (var producto in productosFiltrados.Where(p => p.Precio > precioMinimo))
                {
                    Console.WriteLine(producto);
                }
            }
            else
            {
                Console.WriteLine("Opción no válida. Regresando al menú principal.");
            }
        }

        private static void ActualizarPrecioProducto(Inventario inventario)
        {
            if (LeerConfirmacion("\n¿Desea actualizar el precio de un producto? (s/n)"))
            {
                string nombreProducto = LeerNombre();
                double nuevoPrecio = LeerPrecio();
                inventario.ActualizarPrecio(nombreProducto, nuevoPrecio);
            }
        }

        private static void EliminarProducto(Inventario inventario)
        {
            if (LeerConfirmacion("\n¿Desea eliminar un producto? (s/n)"))
            {
                string nombreProducto = LeerNombre();
                inventario.EliminarProducto(nombreProducto);
            }
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
                    Console.WriteLine("Lo siento, Debe ingresar un número entero positivo para la cantidad de productos.");
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