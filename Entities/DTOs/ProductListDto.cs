using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductListDto:DtoGetBase
    {
        public IList<Product> Products { get; set; }
    }
}
