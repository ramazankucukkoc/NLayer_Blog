using Core.Entities;
using Entities.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public class ArticleUpdateDto : DtoGetBase
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Thumbnail { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        public string SeoAuthor { get; set; }

        public string SeoDescription { get; set; }

        public string SeoTags { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [DisplayName("Aktif Mi?")]

        public bool IsActive { get; set; }
        [DisplayName("Silinsin Mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public bool IsDeleted { get; set; }

    }
}
