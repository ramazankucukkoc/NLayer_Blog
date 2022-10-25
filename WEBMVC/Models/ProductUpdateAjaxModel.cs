using Entities.DTOs;

namespace WEBMVC.Models
{
    public class ProductUpdateAjaxModel
    {
        public ProductUpdateDto ProductUpdateDto { get; set; }

        public string ProductAddPartial { get; set; }
        public ProductDto ProductDto { get; set; }
    }
}
