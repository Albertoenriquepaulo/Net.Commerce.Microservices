using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Catalog.Persistence.Database;
using Catalog.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;

namespace Catalog.Service.Queries
{
    public class ProductQueryService : IProductQueryService
    {
        private readonly ApplicationDbContext _context;

        public ProductQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<ProductDto>> GetAllAsync(int page, int take, IEnumerable<int> products = null)
        {
            var collection = await _context.Products.Where(x => products == null || products.Contains(x.Id))
                                                    .OrderByDescending(x => x.Id)
                                                    .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ProductDto>>();
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            var product = await _context.Products.SingleAsync(x => x.Id == id);

            return product.MapTo<ProductDto>();
        }
    }
}
