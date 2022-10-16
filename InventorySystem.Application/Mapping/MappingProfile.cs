using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InventorySystem.Application.Commands;
using InventorySystem.Application.Models;
using InventorySystem.Domain.Products;

namespace InventorySystem.Application.Mapping
{
    /// <summary>
    /// Perfil de mapeos.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            _ = this.CreateMap<Product, CreateProductCommand>();
            _ = this.CreateMap<Product, ProductQuery>();
            _ = this.CreateMap<ProductQuery, Product>();
        }
    }
}
