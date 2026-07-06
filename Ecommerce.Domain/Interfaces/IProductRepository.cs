using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces
{
   public interface IProductRepository
    {
        Task<Product?>GetByIdAsync(Guid id);
        Task<List<Product>> GetAllAsync();
        Task AddAsync(Product product);
    }
}
