using System;
using System.Collections.Generic;
using System.Text;
using InventorySystem.Domain.Commons;

namespace InventorySystem.Domain.Products
{
    /// <summary>
    /// Clase que contien un producto.
    /// </summary>
    public class Product : Entity, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name">Nombre del producto.</param>
        /// <param name="description">Descripcion del producto.</param>
        /// <param name="stock">Unidades disponibles.</param>
        /// <param name="costamount">Coste del producto.</param>
        /// <param name="dateExpiry">Fecha de vencimiento.</param>
        public Product(string name, string description, int stock, decimal costamount, DateTime dateExpiry)
        {
            this.Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
            this.Description = description;
            this.Stock = stock;
            this.CostAmount = costamount;
            this.DateExpiry = dateExpiry;
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        protected Product()
        {
        }

        /// <summary>
        /// Gets or sets nombre del producto.
        /// </summary>
        public string? Name { get; protected set; }

        /// <summary>
        /// Gets or sets descripción del producto.
        /// </summary>
        public string? Description { get; protected set; }

        /// <summary>
        /// Gets or sets número de unidades disponibles.
        /// </summary>
        public int Stock { get; protected set; }

        /// <summary>
        /// Gets or sets coste del producto.
        /// </summary>
        public decimal CostAmount { get; protected set; }

        /// <summary>
        /// Gets or sets fecha de caducidad.
        /// </summary>
        public DateTime DateExpiry { get; protected set; }
    }
}
