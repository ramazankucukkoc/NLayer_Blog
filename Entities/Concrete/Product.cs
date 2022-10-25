﻿using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product:EntityBase,IEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<CompanyTransaction> CompanyTransactions { get; set; }
        public ICollection<CustomerTransaction> CustomerTransactions { get; set; }

    }
}
