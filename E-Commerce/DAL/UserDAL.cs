using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.DAL
{
    public class UserDAL
    {
        MySQLPersistence _bd = new MySQLPersistence();


        public bool Select(int Id, Models.User user)
        {
            bool ok = false;

            //string select = "select * from user where IdUser = " + Id;
            string select = $"select * from user where IdUser = {Id}";

            DbDataReader dr = _bd.ExecuteSelect(select);

            if (dr.HasRows)
            {
                ok = true; 

                user = new Models.User();
                dr.Read();

                user.Id = Convert.ToInt32(dr["IdUser"]);
                user.Name = dr["Name"].ToString();
                user.Email = dr["Email"].ToString();
                user.Password = dr["Password"].ToString();
            }

            _bd.Close();

            return ok;
        }

        public bool Insert(Models.User user)
        {
            //Mapeamento Objeto-Relacional
            string sql = @"insert user (Name, Email, Password) values (@Name, @Email, @Password)";

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Name", user.Name);
            param.Add("@Email", user.Email);
            param.Add("@Password", user.Password);

            int qtdLinhas = _bd.ExecuteNonQuery(sql, param);

            return qtdLinhas > 0;
        }

        public bool AuthentifyUser(string Email, string Password)
        {
            string select = "select count(*) from user where Email = @Email and Password = @Password";

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Email", Email);
            param.Add("@Password", Password);

            object retorno = _bd.ExecuteSelectScalar(select, param);

            if (retorno == null || Convert.ToInt32(retorno) == 0)
                return false;

            return true;
        }
    }
}
