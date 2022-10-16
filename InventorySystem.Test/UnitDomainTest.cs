using InventorySystem.Domain.Products;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace InventorySystem.Test
{
    /// <summary>
    /// Clase test para el dominio.
    /// </summary>
    public class UnitDomainTest
    {
        private readonly ITestOutputHelper output;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitDomainTest"/> class.
        /// </summary>
        /// <param name="output">Objecto de tipo ITestOutputHelper.</param>
        public UnitDomainTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// Metodo que crea un nuevo producto.
        /// </summary>
        [Fact]
        public void Add()
        {
            var result = new Product("Name", "Description", 55, 9.99M, DateTime.Now);
            Assert.NotNull(result);
            this.output.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Metodo para validar excepción del dominio si el nombre está vacío.
        /// </summary>
        [Fact]
        public void Add_Product_Without_Name_Exception()
        {
            var exception = Assert.Throws<ArgumentNullException>(
                   () => new Product(string.Empty, "Description", 55, 9.99M, DateTime.Now));
            Assert.True(exception.Message == "Value cannot be null. (Parameter 'name')");
        }
    }
}