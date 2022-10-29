namespace Entities.DTOs
{
    public class PersonelUpdateDto
    {
        public int Id { get; set; }
        public string PersonelName { get; set; }
        public string LastName { get; set; }
        public int DepartmanId { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }

    }
}
