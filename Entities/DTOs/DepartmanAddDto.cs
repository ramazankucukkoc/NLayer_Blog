using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DepartmanAddDto
    {
        public string DepartmanName { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
    }
}
