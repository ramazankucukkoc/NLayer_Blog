using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CompanyTransactionUpdateDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CompanyId { get; set; }
        public int PersonelId { get; set; }
        public int Unit { get; set; }//(Adet)
        public int UnitPrice { get; set; }//(Birim fiyat)
        public int TotalPrice { get; set; }
        public int Descripttion { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }
    }
}
