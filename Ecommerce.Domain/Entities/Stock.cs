using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Entities
{
    public class Stock
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid WareHouseId { get; set; }
        public WareHouse Warehouse { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
