using Ecommerce.Domain.Entities;

namespace ecommerce.Application.Dtos
{
    public static class MappingExtensions
    {
        public static CartDto ToDo(this Cart cart)
        {
            return new CartDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = cart.Items.Select(i => new CartItemDto
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            };
        }
        public static OrderDto ToDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                TotalAmount = order.TotalAmount,
                Status = order.Status.ToString(),
                Items = order.Items.Select(i => new OrderItemDto{
                    Id = i.ProductId,
                    Quantity=i.Quantity,
                    UnitPrice=i.UnitPrice
                }).ToList()
            };
        }
    }
}
