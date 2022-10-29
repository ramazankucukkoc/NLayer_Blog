using Entities.DTOs;

namespace WEBMVC.Models
{
    public class DepartmanUpdateAjaxModel
    {
        public DepartmanUpdateDto DepartmanUpdateDto { get; set; }

        public string DepartmanUpdatePartial { get; set; }
        public DepartmanDto DepartmanDto { get; set; }
    }
}
