using Entities.DTOs;

namespace WEBMVC.Models
{
    public class CategoryUpdateAjaxModel
    {
        public CategoryUpdateDto CategoryUpdateDto { get; set; }

        public string CategoryUpdatePartial { get; set; }
        public CategoryDto CategoryDto { get; set; }
    }
}
