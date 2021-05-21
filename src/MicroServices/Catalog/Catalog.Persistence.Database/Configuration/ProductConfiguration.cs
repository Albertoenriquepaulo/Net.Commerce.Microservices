using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistence.Database.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(x => x.Id);
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityTypeBuilder.Property(x => x.Description).IsRequired().HasMaxLength(500);

            //Seed - Products by default
            var products = new List<Product>();
            var random = new Random();

            for (var i = 0; i < 101; i++)
            {
                products.Add(new Product()
                {
                    Id = i,
                    Name = $"Product {i}",
                    Description = $"Description of product {i}",
                    Price = random.Next(100, 1000),
                });
            }

            entityTypeBuilder.HasData(products);

        }


    }
}
