using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using InventorySystem.Application.Commands;
using InventorySystem.Application.Interfaces;
using InventorySystem.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace InventorySystem.API.Controllers
{
    /// <summary>
    /// Controlador.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly ILogger<ProductController> logger;
        private readonly IProductQueries queries;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="mediator">Objecto mediator.</param>
        /// <param name="mapper">Objecto IMapper.</param>
        /// <param name="logger">Objecto log.</param>
        /// <param name="queries">Objecto para consultas.</param>
        public ProductController(IMediator mediator, IMapper mapper, ILogger<ProductController> logger, IProductQueries queries)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        /// <summary>
        /// Permite crear un nuevo producto.
        /// </summary>
        /// <param name="command">Objecto de tipo CreateProductCommand.</param>
        /// <returns>Devuelve el producto creado.</returns>
        /// <response code="200">Objeto ProductQuery.</response>
        /// <response code="422">Unprocessable entity.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ProductQuery), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.UnprocessableEntity)]
        [SwaggerOperation("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            if (command == null)
            {
                return this.UnprocessableEntity();
            }

            var commandResult = await this.mediator.Send(command);

            return this.Ok(commandResult);
        }

        /// <summary>
        /// Permite eliminar un producto.
        /// </summary>
        /// <param name="command">Objecto de tipo DeleteProductCommand.</param>
        /// <returns>Devuelve un ok si todo ha ido de forma correcta.</returns>
        /// <response code="200">Todo correcto.</response>
        /// <response code="422">Unprocessable entity.</response>
        [HttpDelete]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [SwaggerOperation("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand command)
        {
            if (command == null)
            {
                return this.UnprocessableEntity();
            }

            var result = this.queries.GetById(command.Id);
            if (result == null)
            {
                return this.NotFound();
            }

            var commandResult = await this.mediator.Send(command);

            return this.Ok(commandResult);
        }

        /// <summary>
        /// Buscar todos los productos disponibles.
        /// </summary>
        /// <returns>Devuelve todos los productos disponibles.</returns>
        /// <response code="200">Lista de productos..</response>
        /// <response code="404">No existe productos.</response>
        [HttpGet("")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<ProductQuery>), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetAll")]
        public IActionResult GetAll()
        {
            var result = this.queries.GetAll();
            if (result != null)
            {
                return this.Ok(result);
            }
            else
            {
                return this.NotFound();
            }
        }

        /// <summary>
        /// Buscar todos los productos disponibles.
        /// </summary>
        /// <param name="name">Nombre por el que buscar.</param>
        /// <returns>Devuelve todos los productos disponibles.</returns>
        /// <response code="200">Lista de productos..</response>
        /// <response code="404">No existe productos.</response>
        [HttpGet("{name}")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<ProductQuery>), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetByName")]
        public IActionResult GetByName(string name)
        {
            var result = this.queries.GetByName(name);
            if (result != null)
            {
                return this.Ok(result);
            }
            else
            {
                return this.NotFound();
            }
        }
    }
}
