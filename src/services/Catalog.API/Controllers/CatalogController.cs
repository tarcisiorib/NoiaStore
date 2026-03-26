using Catalog.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static WebAPI.Core.Identity.CustomAuthorization;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Authorize]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [AllowAnonymous]
        [HttpGet("catalog/products")]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productRepository.GetAll();
        }

        [ClaimsAuthorize("Catalog","Read")]
        [HttpGet("catalog/products/{id}")]
        public async Task<Product> Get(Guid id)
        {
            return await _productRepository.GetById(id);
        }
    }
}
