using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.DAL
{
    public class ProductDAL
    {
        MySQLPersistence _bd = new MySQLPersistence();

        public bool Insert(Models.Product prod)
        {
            string sql = @"insert product (Name, Category, SellPrice, BuyPrice) values (@Name, @Category, @SellPrice, @BuyPrice)";

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Name", prod.Name);
            param.Add("@Category", prod.Category);
            param.Add("@SellPrice", prod.SellPrice);
            param.Add("@BuyPrice", prod.BuyPrice);

            int qtdLinhas = _bd.ExecuteNonQuery(sql, param);

            return qtdLinhas > 0;
        }
    }
}
