using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InventorySystem.Application.Interfaces;
using InventorySystem.Application.Models;
using InventorySystem.Domain.Products;
using Microsoft.Extensions.Logging;

namespace InventorySystem.Application.Queries
{
    /// <summary>
    /// Consultas al respositorio relacionados con el producto.
    /// </summary>
    public class ProductQueries : IProductQueries
    {
        private readonly IMapper mapper;
        private readonly ILogger<ProductQueries> logger;
        private readonly IProductQueryRepository query;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductQueries"/> class.
        /// </summary>
        /// <param name="query">Objecto para consultas al repositorio.</param>
        /// <param name="mapper">Objecto mapper.</param>
        /// <param name="logger">Objecto para log.</param>
        public ProductQueries(IProductQueryRepository query, IMapper mapper, ILogger<ProductQueries> logger)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.query = query ?? throw new ArgumentNullException(nameof(query));
        }

        /// <inheritdoc/>
        public IEnumerable<ProductQuery> GetAll()
        {
            return this.mapper.Map<IEnumerable<ProductQuery>>(this.query.GetAll());
        }

        /// <inheritdoc/>
        public ProductQuery GetById(Guid id)
        {
            return this.mapper.Map<ProductQuery>(this.query.GetById(id));
        }

        /// <inheritdoc/>
        public IEnumerable<ProductQuery> GetByName(string name)
        {
            return this.mapper.Map<IEnumerable<ProductQuery>>(this.query.GetByName(name));
        }
    }
}
