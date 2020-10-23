using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class User
    {
        int _id;
        string _name;
        string _email;
        string _password;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }

        public User()
        { }

        public bool AuthentifyPassword(string email, string password)
        {
            return email == "a@a.com" && password == "123";
        }

        public bool Insert()
        {
            DAL.UserDAL ud = new DAL.UserDAL();
            User u = new User();
            ud.Insert(u);

            return true;
        }

        /*
         * nomeCompletoDoCliente: camelcase
         * NomeCompletoDoCliente: pascalcase
         * nome_completo_do_cliente: snackcase
         * 
         * case recomendados para C#
         * nome de atributo: _nome
         * nome de var: nome
         * nome de parâmetro: nome
         * nome de metodo: GravarCliente(string nome)
         * nome de classe: NomeDaClasse
        */
    }
}
