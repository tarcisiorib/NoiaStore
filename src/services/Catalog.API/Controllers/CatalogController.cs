using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("catalog/products")]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productRepository.GetAll();
        }

        [HttpGet("catalog/products/{id}")]
        public async Task<Product> Get(Guid id)
        {
            return await _productRepository.GetById(id);
        }
    }
}
