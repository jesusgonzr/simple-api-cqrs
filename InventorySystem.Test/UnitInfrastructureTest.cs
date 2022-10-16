using InventorySystem.Domain.Products;
using InventorySystem.Infrastructure;
using InventorySystem.Infrastructure.Queries;
using InventorySystem.Infrastructure.Rpositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace InventorySystem.Test
{
    /// <summary>
    /// Clase test para el dominio.
    /// </summary>
    public class UnitInfrastructureTest
    {
        private readonly ITestOutputHelper output;
        private readonly ProductRepository repository;
        private readonly ProductQuery repositoryQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitInfrastructureTest"/> class.
        /// </summary>
        /// <param name="output">Objecto de tipo ITestOutputHelper.</param>
        public UnitInfrastructureTest(ITestOutputHelper output)
        {
            this.output = output;

            // Creo un contexto en memoria para las pruebas.
            var contextOptions = new DbContextOptionsBuilder<InventorySystemContext>()
               .UseInMemoryDatabase("InventorysystemDBTest")
               .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
               .Options;
            var context = new InventorySystemContext(contextOptions);

            // Borramos la base de datos en memoria antes de volver a crearla.
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Agrego algunos datos al contexto
            context.AddRange(
                new Product("Samsung Galaxy A50", "Samsung Galaxy A50 - Smartphone de 6.4'' FHD sAmoled Infinity U Display(4 GB RAM, 128 GB ROM, 25 MP, Exynos 9610, Carga rápida)", 55, 299.98M, DateTime.Now.AddDays(30)),
                new Product("Redmi Note 10 5G 4GB+128GB", "Xiaomi Redmi Note 10 5G Smartphone,4GB+128GB Teléfono con NFC,MediaTek Helio G95 Procesador,6.5'' FHD + Dot Pantalla(48MP + 2MP + 2MP + 8MP) Quad Camera, Dual SIM 5g + 5g, AI Face Unlock Versión Global(Gris) ", 55, 186M, DateTime.Now.AddDays(30)));
            context.SaveChanges();

            // Inicializamos el repositorio
            repository = new ProductRepository(context);
            repositoryQuery = new ProductQuery(context);
        }

        /// <summary>
        /// Metodo que crea un nuevo producto.
        /// </summary>
        [Fact]
        public void Add()
        {
            var result = new Product("Redmi Note 10 5G 4GB 64GB", "Xiaomi Redmi Note 10 5G Smartphone, 4GB 64GB Teléfono,DotDisplay FHD+ de 6,5'',MediaTek Dimensity 700,Cámara Triple(48MP+2MP+2MP+8MP), Versión Global(Gris)", 55, 186M, DateTime.Now.AddDays(30));
            this.repository.Add(result);
            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Metodo que consulta por nombre del producto.
        /// </summary>
        [Fact]
        public void GetByName()
        {
            var result = this.repositoryQuery.GetByName("Samsung Galaxy A50");
            Assert.NotNull(result);
            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Metodo que obtiene todos los productos.
        /// </summary>
        [Fact]
        public void GetAll()
        {
            var result = this.repositoryQuery.GetAll();
            Assert.NotNull(result);
            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Metodo que borra un producto.
        /// </summary>
        [Fact]
        public void Delete()
        {
            string name = "Samsung Galaxy A50";
            
            // Busco el producto
            var result = this.repositoryQuery.GetByName(name);
            
            // Lo borro del repositorio
            this.repository.Delete(result.FirstOrDefault().Id);
            
            // Intento localizarlo de nuevo.
            Assert.False(this.repositoryQuery.GetByName(name).ToList().Any());
            
            // Resultado
            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }
    }
}