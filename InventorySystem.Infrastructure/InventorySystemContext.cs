using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Infrastructure
{
    /// <summary>
    /// Contexto.
    /// </summary>
    public class InventorySystemContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventorySystemContext"/> class.
        /// </summary>
        /// <param name="options">Parametro de tipo contexto.</param>
        public InventorySystemContext(DbContextOptions<InventorySystemContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets ThirdParties table.
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }
    }
}
