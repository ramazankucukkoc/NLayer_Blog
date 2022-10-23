using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ArticleAddDto
    {
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
    
        public bool IsActive { get; set; }
    }
}
