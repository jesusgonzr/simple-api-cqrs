using System;
using System.Collections.Generic;
using System.Text;
using InventorySystem.Domain.Products;

namespace InventorySystem.Application.Interfaces
{
    /// <summary>
    /// Interfaz para consultas al repositorio.
    /// </summary>
    public interface IProductQueryRepository
    {
        /// <summary>
        /// Busca un producto por el identificador.
        /// </summary>
        /// <param name="id">Identintificador.</param>
        /// <returns>El producto encontrado o nulo.</returns>
        Product GetById(Guid id);

        /// <summary>
        /// Obtiene un producto por nombre.
        /// </summary>
        /// <param name="name">Nombre del producto.</param>
        /// <returns>La lista de productos encontrados.</returns>
        IEnumerable<Product> GetByName(string name);

        /// <summary>
        /// Obtiene un producto por nombre.
        /// </summary>
        /// <returns>La lista de productos encontrados.</returns>
        IEnumerable<Product> GetAll();
    }
}
