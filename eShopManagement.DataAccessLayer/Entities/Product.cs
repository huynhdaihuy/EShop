namespace eShopManagement.DataAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public required int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
