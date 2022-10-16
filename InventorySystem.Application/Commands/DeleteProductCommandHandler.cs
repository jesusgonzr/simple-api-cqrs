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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly ILogger<DeleteProductCommand> logger;
        private readonly IProductRepository repository;
        private readonly IProductQueryRepository query;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteProductCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Objecto para la manipulación del repositorio.</param>
        /// <param name="query">Objecto para consultas al repositorio.</param>
        /// <param name="mapper">Objecto mapper.</param>
        /// <param name="logger">Objecto para log.</param>
        public DeleteProductCommandHandler(IProductRepository repository, IProductQueryRepository query, ILogger<DeleteProductCommand> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.query = query ?? throw new ArgumentNullException(nameof(query));
        }

        /// <inheritdoc/>
        public Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Comprobamos si el nombre existe en el sistema.
                var productExists = this.query.GetById(request.Id);
                if (productExists == null)
                {
                    string message = $"Product {request.Id} not exists";
                    this.logger.LogError(message);
                    throw new Exception(message);
                }

                // Trasformo el comando en el objeto del repositorio y lo doy de alta.
                this.logger.LogInformation($"Command object: {0}", request);

                // Se agrega el nuevo objecto al repositorio.
                this.logger.LogInformation($"Product object: {0}", productExists);
                this.repository.Delete(request.Id);
                this.logger.LogInformation($"Operation completed");

                // Return object
                return Task.FromResult<int>(1);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Error creating a product.", request);
                throw;
            }
        }
    }
}
