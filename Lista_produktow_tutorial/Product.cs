using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_produktow_tutorial
{
    public class Product : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Product(int id, string name, decimal price, DateTime expirationDate)
        {
            Id = id;
            Name = name;
            Price = price;
            ExpirationDate = expirationDate;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
