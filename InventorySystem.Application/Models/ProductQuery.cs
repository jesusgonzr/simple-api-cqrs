using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Application.Models
{
    /// <summary>
    /// Modelo de respuesta.
    /// </summary>
    public class ProductQuery
    {
        /// <summary>
        /// Gets or sets Identificador del producto.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets nombre del producto.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets descripción del producto.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets número de unidades disponibles.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Gets or sets coste del producto.
        /// </summary>
        public decimal CostAmount { get; set; }

        /// <summary>
        /// Gets or sets fecha de caducidad.
        /// </summary>
        public DateTime DateExpiry { get; set; }
    }
}
