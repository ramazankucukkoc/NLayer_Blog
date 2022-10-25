using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyTransaction:EntityBase,IEntity
    {
        public int ProductId { get; set; }
        public int CompanyId { get; set; }
        public int PersonelId { get; set; }
        public int Unit { get; set; }//(Adet)
        public int UnitPrice { get; set; }//(Birim fiyat)
        public int TotalPrice { get; set; }
        public int Descripttion { get; set; }
        public Product Product { get; set; }
        public Personel Personel { get; set; }
        public Company Company { get; set; }

    }
}
