namespace Entities.DTOs
{
    public class DepartmanUpdateDto
    {
        public int Id { get; set; }
        public string DepartmanName { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }
    }
}
