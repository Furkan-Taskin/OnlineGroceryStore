using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Take_Home_5
{
    public class ProductClass
    {
        public ProductClass()
        {
        }
       public ProductClass(string name, double price, string description, string fileName)
        {
            this.name = name;
            this.price = price;
            this.description = description;
            this.fileName = fileName;
        }
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string fileName { get; set; }

        public override string ToString()
        {
            return this.name;
        }

    }
}
