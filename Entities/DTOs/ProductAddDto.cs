namespace Entities.DTOs
{
    public class ProductAddDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
    }
}
