using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _context;

        public StockRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Stock?>GetStockAsync(Guid productId,Guid warehouseId)
        {
            return await _context.Stocks
                .FirstOrDefaultAsync(s => s.ProductId == productId && s.WareHouseId == warehouseId);
        }

        public async Task<Stock?>GetPrimaryStockAsync(Guid productId)
        {
            return await _context.Stocks
                .Where(s => s.ProductId == productId)
                .OrderByDescending(s => s.Quantity)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Stock>>GetOtherStockWithAvailability(Guid productId,int requiredQty,Guid excludereWareHouseId)
        {
            return await _context.Stocks
                .Where(s => s.ProductId == productId
                && s.WareHouseId != excludereWareHouseId
                && s.Quantity >= requiredQty).ToListAsync();
        }
        public async Task<Stock>GetOrCreateStockAsync(Guid productId,Guid warehouseId)
        {
            var stock=await GetStockAsync(productId,warehouseId);
            if(stock is null)
            {
                stock = new Stock { ProductId = productId, WareHouseId = warehouseId, Quantity = 0 };
                await _context.Stocks.AddAsync(stock);
            }
            return stock;
        }
        public async Task UpdateAsync(Stock stock)
        {
            _context.Stocks.Update(stock);
            await Task.CompletedTask;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
