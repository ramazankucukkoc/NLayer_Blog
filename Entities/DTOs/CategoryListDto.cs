using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CategoryListDto: DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}
