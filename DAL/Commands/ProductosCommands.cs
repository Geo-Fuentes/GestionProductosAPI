using Azure;
using Azure.Core;
using DAL.Conexion;
using Dapper;
using ENTITIES.Entities;
using ENTITIES.Request;
using ENTITIES.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Commands
{
    public class ProductosCommands
    {
        private readonly DbConnect _dbConnect;

        public ProductosCommands(DbConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public async Task<GenericResponse> InsertarProducto(ProductoRequest request)
        {
            return await EjecutarSPGestionDeProductos(request, "I");
        }

        public async Task<GenericResponse> EditarProducto(ProductoRequest request)
        {
            return await EjecutarSPGestionDeProductos(request, "A");
        }

        public async Task<GenericResponse> EliminarProducto(ProductoRequest request)
        {
            return await EjecutarSPGestionDeProductos(request, "E");
        }

        public async Task<GenericResponse<List<Productos>>>ObtenerProductos(int? IdProducto)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@P_ID_PRODUCTO", IdProducto, DbType.Int64);

                using var connection = _dbConnect.GetConnection();
                var datos = await connection.QueryAsync<Productos>("SP_LISTADO_PRODUCTOS", parameters, commandType: CommandType.StoredProcedure);

                return new GenericResponse<List<Productos>>()
                {
                    Code = 1,
                    Message = "OK",
                    Model = datos.ToList()
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<Productos>>() 
                {
                    Code = 0,
                    Message = ex.Message,
                    Model = []
                };
            }
        }

        private async Task<GenericResponse> EjecutarSPGestionDeProductos(ProductoRequest request, string Modo)
        {
            GenericResponse response = new();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@P_OPERACION", Modo, DbType.String);
                parameters.Add("@P_ID_PRODUCTO", request.IdProducto, DbType.Int64);
                parameters.Add("@P_NOMBRE", request.NombreProducto, DbType.String);
                parameters.Add("@P_DESCRIPCION", request.Descripcion, DbType.String);
                parameters.Add("@P_PRECIO_BASE", request.PrecioBase, DbType.Decimal);
                parameters.Add("@P_PRECIO_DESCUENTO", request.PrecioDescuento, DbType.Decimal);
                parameters.Add("@P_IMAGEN", request.Imagen, DbType.String);
                parameters.Add("@P_CODIGO", dbType: DbType.String, direction: ParameterDirection.Output, size: 1);
                parameters.Add("@P_MENSAJE", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);

                using var connection = _dbConnect.GetConnection();
                await connection.ExecuteAsync("SP_PRODUCTOS", parameters, commandType: CommandType.StoredProcedure);

                string mensaje = parameters.Get<string>("@P_MENSAJE");
                string codigo = parameters.Get<string>("@P_CODIGO");

                response.Code = int.Parse(codigo);
                response.Message = mensaje;

            }
            catch (Exception ex)
            {
                response.Code = 0;
                response.Message = $"Error: {ex.Message}";
            }

            return response;
        }

    }
}
