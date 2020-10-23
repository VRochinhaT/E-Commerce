using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.DAL
{
    public class UserDAL
    {
        MySQLPersistence _bd = new MySQLPersistence();

        public void Insert(Models.User user)
        {
            //Mapeamento Objeto-Relacional
            string sql = @"insert user (Name, Email, Password) values (@Name, @Email, @Password)";

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Name", user.Name);
            param.Add("@Email", user.Email);
            param.Add("@Password", user.Password);

            _bd.ExecuteNonQuery(sql, param);
        }
    }
}
