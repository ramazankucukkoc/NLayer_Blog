namespace Entities.DTOs
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }
    }
}
