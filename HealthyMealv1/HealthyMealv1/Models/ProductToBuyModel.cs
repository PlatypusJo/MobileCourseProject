using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyMealv1.Models
{
    public class ProductToBuyModel
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string UnitsId { get; set; }
        public string UnitsName { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsBuy { get; set; }

    }
}
