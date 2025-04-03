using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Request
{
    public class ProductoRequest
    {
        public int? IdProducto { get; set; }
        public string NombreProducto {  get; set; }
        public string? Descripcion { get; set; }
        public decimal? PrecioBase {  get; set; }
        public decimal? PrecioDescuento {  get; set; }
        public string? Imagen {  get; set; }
    }
}
