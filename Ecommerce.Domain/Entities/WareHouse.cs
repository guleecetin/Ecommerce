namespace Ecommerce.Domain.Entities
{
    public class WareHouse
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    }
}
