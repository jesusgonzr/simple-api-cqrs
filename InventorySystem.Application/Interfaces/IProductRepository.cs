using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Domain.Commons;
using InventorySystem.Domain.Products;

namespace InventorySystem.Application.Interfaces
{
    /// <summary>
    /// Interfaz para la integracón con el repositorio.
    /// </summary>
    public interface IProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Añade un producto al repositorio.
        /// </summary>
        /// <param name="product">Objeto Product.</param>
        void Add(Product product);

        /// <summary>
        /// Elimina un producto del repositorio.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        void Delete(Guid id);
    }
}
