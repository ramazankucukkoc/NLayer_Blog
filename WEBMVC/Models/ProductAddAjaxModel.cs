using Entities.DTOs;

namespace WEBMVC.Models
{
    public class ProductAddAjaxModel
    {
        public ProductAddDto ProductAddDto { get; set; }

        public string ProductAddPartial { get; set; }
        public ProductDto ProductDto { get; set; }

    }
}
