using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyMealv1.Models
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string FoodId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Brand { get; set; }
    }
}
