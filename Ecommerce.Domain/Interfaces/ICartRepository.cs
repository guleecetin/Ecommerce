using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart?> GetByUserIdAsync(Guid userId);
        Task<Cart> GetOrCreateAsync(Guid userId);
        Task SaveAsync(Cart cart);
        Task ClearAsync(Guid cartId);
    }
}
