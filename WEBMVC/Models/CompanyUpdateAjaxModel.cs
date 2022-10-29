using Entities.DTOs;

namespace WEBMVC.Models
{
    public class CompanyUpdateAjaxModel
    {
        public CompanyUpdateDto CompanyUpdateDto { get; set; }
        public string CompanyUpdatePartial { get; set; }
        public CompanyDto CompanyDto { get; set; }
    }
}
