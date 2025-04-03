using BAL.UseCases;
using ENTITIES.Entities;
using ENTITIES.Request;
using ENTITIES.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionProductosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosUseCase _productosUseCase;

        public ProductosController(ProductosUseCase productosUseCase)
        {
            _productosUseCase = productosUseCase;
        }

        [HttpPost("InsertarProducto")]
        public async Task<GenericResponse> InsertarProducto([FromBody] ProductoRequest request)
        {
            return await _productosUseCase.InsertarProducto(request);
        }

        [HttpPut("EditarProducto")]
        public async Task<GenericResponse> EditarProducto([FromBody] ProductoRequest request)
        {
            return await _productosUseCase.EditarProducto(request);
        }

        [HttpDelete("EliminarProducto")]
        public async Task<GenericResponse> EliminarProducto([FromQuery] int IdProducto)
        {
            return await _productosUseCase.EliminarProducto(IdProducto);
        }

        [HttpGet("ObtenerTodosLosProductos")]
        public async Task<GenericResponse<List<Productos>>> ObtenerTodosLosProductos()
        {
            return await _productosUseCase.ObtenerProductos(null);
        }

        [HttpGet("ObtenerProductosPorId")]
        public async Task<GenericResponse<List<Productos>>> ObtenerProductosPorId([FromQuery] int IdProducto)
        {
            return await _productosUseCase.ObtenerProductos(IdProducto);
        }
    }
}
