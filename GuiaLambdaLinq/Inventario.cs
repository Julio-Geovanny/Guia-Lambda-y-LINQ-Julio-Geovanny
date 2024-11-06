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
    }
}
