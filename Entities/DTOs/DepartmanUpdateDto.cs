using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DepartmanUpdateDto
    {
        public int Id { get; set; }
        public string DepartmanName { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }
    }
}
