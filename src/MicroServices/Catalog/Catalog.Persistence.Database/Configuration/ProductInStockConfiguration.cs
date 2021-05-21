using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain;

namespace Catalog.Persistence.Database.Configuration
{
    public class ProductInStockConfiguration
    {
        public ProductInStockConfiguration(EntityTypeBuilder<ProductInStock> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(x => x.Id);

            var products = new List<ProductInStock>();
            var random = new Random();

            for (var i = 0; i < 101; i++)
            {
                products.Add(new ProductInStock()
                {
                    Id = i,
                    ProductId = i,
                    Stock = random.Next(0, 20)
                });
            }

            entityTypeBuilder.HasData(products);
        }
    }
}
