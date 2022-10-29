namespace Entities.DTOs
{
    public class CompanyAddDto
    {
        public string CompanyName { get; set; }
        public string DepartmanName { get; set; }//(Sektör)
        public string Manager { get; set; }//müdür yetkili
        public string CompanyPhone { get; set; }
        public string ManagerPhone { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
    }
}
