using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Application.Interfaces;
using InventorySystem.Domain.Products;

namespace InventorySystem.Infrastructure.Queries
{
    /// <summary>
    /// Repositorio de consultas.
    /// </summary>
    public class ProductQuery : IProductQueryRepository
    {
        private readonly InventorySystemContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductQuery"/> class.
        /// </summary>
        /// <param name="context">Contexto de la base de datos.</param>
        public ProductQuery(InventorySystemContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public IEnumerable<Product> GetAll()
        {
            return this.context.Products.ToList();
        }

        /// <inheritdoc/>
        public Product GetById(Guid id)
        {
            return this.context.Products.Where(o => o.Id == id).FirstOrDefault();
        }

        /// <inheritdoc/>
        public IEnumerable<Product> GetByName(string name)
        {
            return this.context.Products.Where(o => o.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
    }
}
