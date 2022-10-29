using Entities.DTOs;

namespace WEBMVC.Models
{
    public class CompanyAddAjaxModel
    {
        public CompanyAddDto CompanyAddDto { get; set; }
        public string CompanyAddPartial { get; set; }
        public CompanyDto CompanyDto { get; set; }
    }
}
