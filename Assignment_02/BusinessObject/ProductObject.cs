﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class ProductObject
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Weight { get; set; }
        public string UnitPrice { get; set; }
        public int UnitslnStock { get; set; }
    }
}
