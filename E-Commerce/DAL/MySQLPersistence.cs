using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace E_Commerce.DAL
{
    public class MySQLPersistence
    {
        public MySqlConnection _conection { get; set; }
        public MySqlCommand _cmd { get; set; }

        int _lastId;
        public int LastId { get => _lastId; set => _lastId = value; }


        public MySQLPersistence()
        {

            _conection = new MySqlConnection();
            _cmd = _conection.CreateCommand();
        }

        public void Open()
        { 
            if(_conection.State != System.Data.ConnectionState.Open)
            {
                _conection.Open();
            }
        }

        public void Close() { _conection.Close(); }

        /// <summary>
        /// Função que executa INSERT, DELETE, INSERT e Store Procedure
        /// </summary>
        /// <param name="sql">Comando SQL</param>
        /// <returns>Quantidade de linhas afetadas no BD</returns>
        public int ExecuteNonQuery(string sql, Dictionary<string, object> param = null)
        {
            Open();
            _cmd.CommandText = sql;

            if(param != null)
            {
                foreach(var p in param)
                {
                    _cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
            }

            int qtnLinhasAfetadas =_cmd.ExecuteNonQuery();

            _lastId = (int)_cmd.LastInsertedId;

            Close();

            return qtnLinhasAfetadas;
        }
    }
}
