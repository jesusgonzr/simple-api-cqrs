using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InventorySystem.Application.Interfaces;
using InventorySystem.Application.Models;
using InventorySystem.Domain.Products;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InventorySystem.Application.Commands
{
    /// <summary>
    /// Implementación de la creación de un producto.
    /// </summary>
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductQuery>
    {
        private readonly IMapper mapper;
        private readonly ILogger<CreateProductCommand> logger;
        private readonly IProductRepository repository;
        private readonly IProductQueryRepository query;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProductCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Objecto para la manipulación del repositorio.</param>
        /// <param name="query">Objecto para consultas al repositorio.</param>
        /// <param name="mapper">Objecto mapper.</param>
        /// <param name="logger">Objecto para log.</param>
        public CreateProductCommandHandler(IProductRepository repository, IProductQueryRepository query,
            IMapper mapper, ILogger<CreateProductCommand> logger)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.query = query ?? throw new ArgumentNullException(nameof(query));
        }

        /// <inheritdoc/>
        public Task<ProductQuery> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Comprobamos si el nombre existe en el sistema.
                var productExists = this.query.GetByName(request.Name);
                if (productExists != null && productExists.Any())
                {
                    string message = $"Product {request.Name} already exist";
                    this.logger.LogError(message);
                    throw new Exception(message);
                }

                // Trasformo el comando en el objeto del repositorio y lo doy de alta.
                this.logger.LogInformation($"Command object: {0}", request);
                var newProduct = new Product(request.Name, request.Description, request.Stock, request.CostAmount, request.DateExpiry);

                // Se agrega el nuevo objecto al repositorio.
                this.logger.LogInformation($"Product object: {0}", newProduct);
                this.repository.Add(newProduct);
                this.logger.LogInformation($"Operation completed");

                // Return object
                return Task.FromResult<ProductQuery>(this.mapper.Map<ProductQuery>(newProduct));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Error creating a product.", request);
                throw;
            }
        }
    }
}
