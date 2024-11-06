using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaLambdaLinq
{
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



    }
}
