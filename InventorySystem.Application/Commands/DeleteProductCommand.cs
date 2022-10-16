using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InventorySystem.Application.Commands
{
    /// <summary>
    /// Modelo para el comando eliminar.
    /// </summary>
    public class DeleteProductCommand : IRequest<int>
    {
        /// <summary>
        /// Gets or sets identificador del producto.
        /// </summary>
        public Guid Id { get; set; }
    }
}
