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
    public class CategoryAddDto:DtoGetBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
       
        public string Note { get; set; }
       
        public bool IsActive { get; set; }
    }
}
