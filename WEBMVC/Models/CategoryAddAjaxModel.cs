using Entities.DTOs;

namespace WEBMVC.Models
{
    public class CategoryAddAjaxModel
    {
        public CategoryAddDto CategoryAddDto { get; set; }

        public string CategoryAddPartial { get; set; }
        public CategoryDto CategoryDto { get; set; }
    }
}
