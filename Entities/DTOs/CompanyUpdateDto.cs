using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CompanyUpdateDto
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }
        public string DepartmanName { get; set; }//(Sektör)
        public string Manager { get; set; }//müdür yetkili
        public string CompanyPhone { get; set; }
        public string ManagerPhone { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }
    }
}
