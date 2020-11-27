using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.DAL
{
    public class ProductDAL
    {
        MySQLPersistence _db = new MySQLPersistence();

        public bool Insert(Models.Product prod)
        {
            string sql = @"insert product (Name, Category, SellPrice, BuyPrice) values (@Name, @Category, @SellPrice, @BuyPrice)";

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Name", prod.Name);
            param.Add("@Category", prod.Category);
            param.Add("@SellPrice", prod.SellPrice);
            param.Add("@BuyPrice", prod.BuyPrice);

            int qtdLinhas = _db.ExecuteNonQuery(sql, param);

            return qtdLinhas > 0;
        }

        public List<Models.Product> Search(string name)
        {
            List<Models.Product> products = new List<Models.Product>();

            string select = $"select * from product where Name like @name";

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@name", "%" + name + "%");

            DbDataReader dr = _db.ExecuteSelect(select, param);

            products = Map(dr);

            _db.Close();

            return products;
        }

        private List<Models.Product> Map(DbDataReader dr)
        {
            List<Models.Product> products = new List<Models.Product>();

            while (dr.Read())
            {
                Models.Product product = new Models.Product();

                product.Id = Convert.ToInt32(dr["IdProduct"]);
                product.Name = dr["Name"].ToString();
                product.Category = dr["Category"].ToString();
                product.SellPrice = Convert.ToDecimal(dr["SellPrice"]); ;
                product.BuyPrice = Convert.ToDecimal(dr["BuyPrice"]); ;

                products.Add(product);
            }

            return products;
        }
    }
}
