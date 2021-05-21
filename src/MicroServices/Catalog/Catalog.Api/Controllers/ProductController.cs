using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Service.Queries;
using Catalog.Service.Queries.DTOs;
using Service.Common.Collection;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;

        private readonly IProductQueryService _productQueryService;

        public ProductController(ILogger<DefaultController> logger, IProductQueryService productQueryService)
        {
            _logger = logger;
            _productQueryService = productQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<ProductDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> productIds = null;

            if (!string.IsNullOrEmpty(ids))
            {
                productIds = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            var result = await _productQueryService.GetAllAsync(page, take, productIds);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id)
        {
            var result = await _productQueryService.GetAsync(id);

            return result;
        }
    }
}
