using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entities
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string NombreProducto {  get; set; }
        public string DescripcionProducto {  get; set; }
        public decimal PrecioBase { get; set; }
        public decimal PrecioDescuento {  get; set; }
        public string ImagenProducto { get; set; }
    }
}
