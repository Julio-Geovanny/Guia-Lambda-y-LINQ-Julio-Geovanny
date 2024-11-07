using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaLambdaLinq
{
    public class Inventario
    {
        private List<Producto> productos;

        public Inventario()
        {
            productos = new List<Producto>();
        }
        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public IEnumerable<Producto> FiltrarYOrdenarProductos(double precioMinimo)
        {
            //filtrar y ordenar los productos con LINQ y expresiones lambda
            return productos
                .Where(p => p.Precio > precioMinimo)    //filtrar productos con precio mayor al minimo especificado
                .OrderBy(p => p.Precio);    //ordena los productos de menor a mayor precio
        }

        public void ActualizarPrecio(string nombre, double nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                Console.WriteLine($"El precio del producto '{nombre}' ha sido actualizado a {nuevoPrecio}.");
            }
            else
            {
                Console.WriteLine($"Producto '{nombre}' no encontrado.");
            }
        }

        public void EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine($"El producto '{nombre}' ha sido eliminado."); 
            }
            else
            {
                Console.WriteLine($"Producto '{nombre}' no encontrado.");
            }
        }

        public void ContarProductosPorRango()
        {
            var conteo = new
            {
                MenoresA100 = productos.Count(p => p.Precio < 100),
                Entre100y500 = productos.Count(p => p.Precio >= 100 && p.Precio <= 500),
                MayoresA500 = productos.Count(p => p.Precio > 500)
            };

            Console.WriteLine($"Conteo de productos:\nMenores a 100: {conteo.MenoresA100}\nEntre 100 y 500: {conteo.Entre100y500}\nMayores a 500: {conteo.MayoresA500}");
        }
    }
}
