using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DepartmanListDto:DtoGetBase
    {
        public IList<Departman> Departmens { get; set; }

    }
}
