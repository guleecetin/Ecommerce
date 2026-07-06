namespace ecommerce.Application.Dtos
{
   public class OrderDto
    {
        public Guid Id { get; set; } 
        public Guid UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<OrderItemDto> Items { get; set; } = new();

    }
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
