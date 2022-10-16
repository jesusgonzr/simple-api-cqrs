using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Application.Interfaces;
using InventorySystem.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Infrastructure.Rpositories
{
    /// <summary>
    /// Repositorio para los productos.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly InventorySystemContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">Contexto de la base de datos.</param>
        public ProductRepository(InventorySystemContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public void Add(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Guid id)
        {
            var product = this.context.Products.Where(o => o.Id == id).FirstOrDefault();
            this.context.Products.Remove(product);
            this.context.SaveChanges();
        }
    }
}
