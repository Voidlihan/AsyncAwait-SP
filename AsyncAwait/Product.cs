using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string Seller { get; set; }
        public Guid SellerId { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime StartDay { get; set; }
    }
}
