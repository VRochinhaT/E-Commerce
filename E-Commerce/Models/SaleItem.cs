using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class SaleItem
    {
        Product _product;
        int _quantity;
        decimal _price;

        public Product Product { get => _product; set => _product = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public decimal Price { get => _price; set => _price = value; }
    }
}
