using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelAddDto
    {
        public string PersonelName { get; set; }
        public string LastName { get; set; }
        public int DepartmanId { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }

    }
}
