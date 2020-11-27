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
        MySQLPersistence _db = new MySQLPersistence();


        public bool Select(int Id, Models.User user)
        {
            bool ok = false;

            //string select = "select * from user where IdUser = " + Id;
            string select = $"select * from user where IdUser = {Id}";

            DbDataReader dr = _db.ExecuteSelect(select);

            if (dr.HasRows)
            {
                ok = true;

                user = Map(dr).First();
            }

            _db.Close();

            return ok;
        }

        public List<Models.User> Search(string name)
        {
            List<Models.User> users = new List<Models.User>();

            string select = $"select * from user where Name like @name";

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@name", "%" + name + "%");

            DbDataReader dr = _db.ExecuteSelect(select, param);

            users = Map(dr);

            _db.Close();

            return users;
        }

        private List<Models.User> Map(DbDataReader dr)
        {
            List<Models.User> users = new List<Models.User>();

            while (dr.Read())
            {
                Models.User user = new Models.User();

                user.Id = Convert.ToInt32(dr["IdUser"]);
                user.Name = dr["Name"].ToString();
                user.Email = dr["Email"].ToString();
                user.Password = dr["Password"].ToString();

                users.Add(user);
            }

            return users;
        }

        public bool Insert(Models.User user)
        {
            MySQLPersistence db = new MySQLPersistence(true);
            bool ok = false;


            try
            {
                db.StartTransaction();


                //Mapeamento Objeto-Relacional
                string sql = @"insert user (Name, Email, Password) values (@Name, @Email, @Password)";

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@Name", user.Name);
                param.Add("@Email", user.Email);
                param.Add("@Password", user.Password);

                int qtdLinhas = db.ExecuteNonQuery(sql, param);

                /*db.CleanParam();

                sql = @"insert user (Name, Email, Password) values (@Name, @Email, @Password)";

                param.Clear();
                param.Add("@Name", user.Name);
                param.Add("@Email", user.Email);
                param.Add("@Password", user.Password);

                qtdLinhas = db.ExecuteNonQuery(sql, param);*/

                ok = qtdLinhas > 0;

                db.TransactionCommit();
            }
            catch
            {
                db.TransactionRollback();
            }
            finally
            {
                db.Close();
            }

            return ok;
        }

        public bool AuthentifyUser(string Email, string Password)
        {
            string select = "select count(*) from user where Email = @Email and Password = @Password";

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Email", Email);
            param.Add("@Password", Password);

            object retorno = _db.ExecuteSelectScalar(select, param);

            if (retorno == null || Convert.ToInt32(retorno) == 0)
                return false;

            return true;
        }
    }
}
