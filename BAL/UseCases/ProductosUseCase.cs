using DAL.Commands;
using ENTITIES.Entities;
using ENTITIES.Request;
using ENTITIES.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.UseCases
{
    public class ProductosUseCase
    {
        private readonly ProductosCommands _productosCommands;

        public ProductosUseCase(ProductosCommands productosCommands)
        {
            _productosCommands = productosCommands;
        }

        public async Task<GenericResponse> InsertarProducto(ProductoRequest productoRequest)
        {
            return await _productosCommands.InsertarProducto(productoRequest);
        }

        public async Task<GenericResponse> EditarProducto(ProductoRequest productoRequest)
        {
            return await _productosCommands.EditarProducto(productoRequest);
        }

        public async Task<GenericResponse> EliminarProducto(int IdProducto) 
        {
            return await _productosCommands.EliminarProducto(new ProductoRequest()
            {
                IdProducto = IdProducto
            });
        }
        public async Task<GenericResponse<List<Productos>>> ObtenerProductos(int? IdProducto)
        {
            return await _productosCommands.ObtenerProductos(IdProducto);
        }
    }
}
