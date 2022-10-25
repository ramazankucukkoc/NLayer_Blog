using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Departman:EntityBase,IEntity
    {
        public string DepartmanName { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}
