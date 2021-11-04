using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Take_Home_5
{
    public class DBProducts
    {
        static public List<ProductClass> products;
        public static int i = 0;
        public static int oldCount = 0;

        static DBProducts()
        {
            products = new List<ProductClass>();
            oldCount = products.Count;
            products.Add(new ProductClass("Apple", 2.9, "Amasya Apple", "Apple.png"));
            products.Add(new ProductClass("Orange", 4.9, "Washington Orange", "Orange.png"));
            products.Add(new ProductClass("Banana", 7.9, "Manavgat Banana", "Banana.png"));
            products.Add(new ProductClass("Tea", 28.9, "Rize Tea", "Tea.png"));
            products.Add(new ProductClass("Sugar", 4.5, "Granulated Sugar", "Sugar.png"));
            products.Add(new ProductClass("Rice", 18.50, "Osmancik Rice", "Rice.png"));
            products.Add(new ProductClass("Water", 7.85, "Düzce Su 19 L", "Water.png"));
            products.Add(new ProductClass("Pencil", 1.25, "Fiber Castle 0.7", "Pencil.png"));
            products.Add(new ProductClass("Cola", 6.95, "LCola 1.25L", "Cola.png"));
            products.Add(new ProductClass("Chips", 8.45, "Doritos Chips 400gr", "Chips.png"));
        }

    }
}
