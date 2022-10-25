using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CompanyTransactionDto : DtoGetBase
    {
        public CompanyTransaction  CompanyTransaction { get; set; }
    }
}
