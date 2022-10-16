using InventorySystem.API.Client;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace InventorySystem.Test
{
    /// <summary>
    /// Clase test para el dominio.
    /// </summary>
    public class UnitTestAPIClient
    {
        private static readonly string urlServices = "https://localhost:44301/";
        private readonly ITestOutputHelper output;
        private readonly HttpClient httpClient;
        private readonly InventorySystemAPIClient apiInstance;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestAPIClient"/> class.
        /// </summary>
        /// <param name="output">Objecto de tipo ITestOutputHelper.</param>
        public UnitTestAPIClient(ITestOutputHelper output)
        {
            this.output = output;
            
            this.httpClient = new System.Net.Http.HttpClient();
            httpClient.BaseAddress = new Uri(urlServices);
            this.apiInstance = new InventorySystemAPIClient(httpClient);

            // Vacio la información
            this.InicializeTest();
        }

        /// <summary>
        /// Metodo que crea un nuevo producto.
        /// </summary>
        [Fact]
        public void O1_AddProduct()
        {
            // Add .
            var result = this.apiInstance.CreateProductAsync( new CreateProductCommand()
                                {
                                    Name = "Nombre del producto",
                                    Description = "Descripcion del producto",
                                    CostAmount = 99.99d,
                                    Stock = 100,
                                    DateExpiry = DateTime.Now.AddDays(30),
                                }
                            ).GetAwaiter().GetResult();
            Assert.NotNull(result);
            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Metodo que busca todos los productos.
        /// </summary>
        [Fact]
        public void O2_GetAll()
        {
            // Get all .
            var result = this.apiInstance.GetAllAsync().GetAwaiter().GetResult();
            Assert.NotNull(result);
            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Metodo que busca un producto por nombre.
        /// </summary>
        [Fact]
        public void O3_GetByNameAsync()
        {
            // Get by name .
            var result = this.apiInstance.GetByNameAsync("Samsung Galaxy A50").GetAwaiter().GetResult();
            Assert.NotNull(result);
            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Metodo que elimina los productos.
        /// </summary>
        [Fact]
        public void O4_DeleteProductAsync()
        {
            // Get all .
            var search = this.apiInstance.GetAllAsync().GetAwaiter().GetResult();

            // Delete .
            foreach (var item in search)
            {
                var result = this.apiInstance.DeleteProductAsync(new DeleteProductCommand()
                {
                    Id = item.Id,
                }).GetAwaiter().GetResult();

                Assert.NotNull(result);
                this.output.WriteLine(JsonConvert.SerializeObject(result));
            }
        }

        private void InicializeTest()
        {
            // Get all.
            var search = this.apiInstance.GetAllAsync().GetAwaiter().GetResult();

            // Vacio el test
            foreach (var item in search)
            {
                _ = this.apiInstance.DeleteProductAsync(new DeleteProductCommand()
                                        {
                                            Id = item.Id,
                                        }).GetAwaiter().GetResult();
            }

            // Agrego algunos datos al contexto
            _ = this.apiInstance.CreateProductAsync(new CreateProductCommand()
                    {
                        Name = "Samsung Galaxy A50",
                        Description = "Samsung Galaxy A50 - Smartphone de 6.4'' FHD sAmoled Infinity U Display(4 GB RAM, 128 GB ROM, 25 MP, Exynos 9610, Carga rápida)",
                        CostAmount = 299.98d,
                        Stock = 100,
                        DateExpiry = DateTime.Now.AddDays(30),
                    }).GetAwaiter().GetResult();
        }
    }
}