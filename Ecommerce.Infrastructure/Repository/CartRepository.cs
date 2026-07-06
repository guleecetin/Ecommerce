using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repository
{
    public class CartRepository:ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Cart?>GetByUserIdAsync(Guid userId)
        {
            return await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }
        public async Task<Cart>GetOrCreateAsync(Guid userId)
        {
            var cart=await GetByUserIdAsync(userId);
            if(cart is null)
            {
                cart=new Cart { UserId=userId };
                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
            }
            return cart;
        }
        public async Task SaveAsync(Cart cart)
        {
            await _context.SaveChangesAsync();
        }
        public async Task ClearAsync(Guid cartId)
        {
            var items = _context.CartItems.Where(i => i.CartId == cartId);
            _context.CartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
