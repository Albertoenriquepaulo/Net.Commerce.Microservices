using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Common;
using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Catalog.Service.EventHandlers
{
    public class ProductInStockUpdateStockEventHandler : INotificationHandler<ProductInStockUpdateStockCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductInStockUpdateStockEventHandler> _logger;

        public ProductInStockUpdateStockEventHandler(ApplicationDbContext context, ILogger<ProductInStockUpdateStockEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(ProductInStockUpdateStockCommand notification, CancellationToken cancellationToken)
        {
            // I use https://papertrailapp.com/ for logging the messsages
            _logger.LogInformation("--- ProductInStockUpdateStockCommand started");

            var products = notification.Items.Select(x => x.ProductId);
            var stocks = await _context.Stocks.Where(x => products.Contains(x.ProductId)).ToListAsync();

            _logger.LogInformation("--- Products retrieved from database");

            foreach (var item in notification.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);

                if (item.Action == Enums.ProductInStockAction.Subtract)
                {
                    if (entry == null || item.Stock > entry.Stock)
                    {
                        var errorMsg = $"--- Product {entry?.ProductId} doesn't have enough stock";
                        _logger.LogError(errorMsg);
                        throw new Exception(errorMsg);
                    }

                    entry.Stock -= item.Stock;

                    _logger.LogInformation($"--- Product {entry?.ProductId} - The stock has been subtracted - new stock {entry?.Stock}");
                }
                else
                {
                    if (entry == null)
                    {
                        entry = new ProductInStock()
                        {
                            ProductId = item.ProductId
                        };

                        await _context.AddAsync(entry);

                        _logger.LogInformation($"--- New stock record was created for {entry?.ProductId} because didn't exist");
                    }

                    entry.Stock += item.Stock;
                    _logger.LogInformation($"--- Product {entry?.ProductId} - The stock was updated and the new stock is {entry?.Stock}");
                }
            }

            await _context.SaveChangesAsync();

            _logger.LogInformation("--- ProductInStockUpdateStockCommand ended");

        }
    }
}
