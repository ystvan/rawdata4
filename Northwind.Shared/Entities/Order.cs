using System;
using System.Collections.Generic;

namespace Northwind.Shared
{
    public class Order : BaseEntity
    {
        public DateTime Date { get; set; }
        public DateTime Required { get; set; }
        public DateTime Shipped { get; set; }
        public double Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
    }
}
