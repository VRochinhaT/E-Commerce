using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Sale
    {
        User _user;
        DateTime _date;
        decimal _total;
        List<SaleItem> _products = new List<SaleItem>();

        public User User { get => _user; set => _user = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public decimal Total { get => _total; set => _total = value; }
        public List<SaleItem> Products { get => _products; set => _products = value; }

        public bool Insert()
        {
            return true;
        }
    }
}
