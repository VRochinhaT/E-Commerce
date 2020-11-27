using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Product
    {
        int _id;
        string _name;
        string _category;
        decimal _sellPrice;
        decimal _buyPrice;

        DAL.ProductDAL pd = new DAL.ProductDAL();

        public Product()
        {
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Category { get => _category; set => _category = value; }
        public decimal SellPrice { get => _sellPrice; set => _sellPrice = value; }
        public decimal BuyPrice { get => _buyPrice; set => _buyPrice = value; }

        public bool Insert()
        {
            return pd.Insert(this);
        }

        public List<Product> Search(string name)
        {
            return pd.Search(name);
        }
    }
}
