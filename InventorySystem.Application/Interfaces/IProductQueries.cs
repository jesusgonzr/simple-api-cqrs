using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Application.Models;

namespace InventorySystem.Application.Interfaces
{
    /// <summary>
    /// Consultas disponibles para el API.
    /// </summary>
    public interface IProductQueries
    {
        /// <summary>
        /// Obtiene todos los productos definidos.
        /// </summary>
        /// <returns>Lista de productos creados.</returns>
        IEnumerable<ProductQuery> GetAll();

        /// <summary>
        /// Obtiene un único producto.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        /// <returns>Objeto con el producto encontrado.</returns>
        ProductQuery GetById(Guid id);

        /// <summary>
        /// Obtiene los productos según el nombre.
        /// </summary>
        /// <param name="name">Valor a buscar.</param>
        /// <returns>Lista de objetos que conindidan con el valor indicado.</returns>
        IEnumerable<ProductQuery> GetByName(string name);
    }
}
