using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces
{
    public interface IStockRepository
    {
        Task<Stock?> GetStockAsync(Guid productId, Guid warehouseId);
        Task<Stock?> GetPrimaryStockAsync(Guid productId);
        Task<Stock> GetOrCreateStockAsync(Guid productId, Guid warehouseId);
        Task<List<Stock>> GetOtherStockWithAvailability(Guid productId, int requiredQty, Guid excludeWarehouseId);
        Task UpdateAsync(Stock stock);
        Task SaveChangesAsync();

    }
}
