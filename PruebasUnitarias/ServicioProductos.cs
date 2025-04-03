using BAL.UseCases;
using DAL.Commands;
using DAL.Conexion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace PruebasUnitarias
{
    public class Tests
    {
        private ServiceProvider _serviceProvider;
        private ProductosUseCase _productos;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            

            services.AddTransient<ProductosCommands>();
            services.AddTransient<ProductosUseCase>();
            services.AddTransient<DbConnect>(provider => new DbConnect("Server=(localdb)\\MSSQLLocalDB;Database=GESTION_PRODUCTOS_DB;Trusted_Connection=True;MultipleActiveResultSets=true"));

            _serviceProvider = services.BuildServiceProvider();

            _productos = _serviceProvider.GetRequiredService<ProductosUseCase>();
        }

        [Test]
        public async Task CrearProducto()
        {
            var resultado = await _productos.InsertarProducto(new ENTITIES.Request.ProductoRequest()
            {
                NombreProducto = "Producto 3",
                Descripcion = "Sin Descripcion",
                PrecioBase = 10.50M
            });

            Assert.IsNotNull(resultado);
        }

        [Test]
        public async Task ObtenerProductos()
        {
            var resultado = await _productos.ObtenerProductos(null);
            Assert.IsNotNull(resultado);
        }


        [TearDown]  
        public void TearDown()
        {
            _serviceProvider?.Dispose();
        }
    }
}