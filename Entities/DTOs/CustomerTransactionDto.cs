using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CustomerTransactionDto:DtoGetBase
    {
        public CustomerTransaction  CustomerTransaction { get; set; }
    }
}
