using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class CategoryUpdateDto: DtoGetBase
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
       
        public string Description { get; set; }
       
        public string Note { get; set; }
        [DisplayName("Aktif Mi?")]

        public bool IsActive { get; set; }
        [DisplayName("Silinsin Mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]

        public bool IsDeleted { get; set; }
    }
}
