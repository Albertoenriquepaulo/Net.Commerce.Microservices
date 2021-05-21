using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.Queries;
using Catalog.Service.Queries.DTOs;
using MediatR;
using Service.Common.Collection;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        private readonly IProductQueryService _productQueryService;

        private readonly IMediator _mediator;

        public ProductController(ILogger<ProductController> logger, IProductQueryService productQueryService, IMediator mediator)
        {
            _logger = logger;
            _productQueryService = productQueryService;
            _mediator = mediator;
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

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();

        }
    }
}
