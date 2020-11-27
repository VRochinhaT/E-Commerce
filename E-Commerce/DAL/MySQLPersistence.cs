using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace E_Commerce.DAL
{
    public class MySQLPersistence
    {
        public MySqlConnection _connection { get; set; }
        public MySqlCommand _cmd { get; set; }
        public MySqlTransaction _trans { get; set; }

        int _lastId;
        public int LastId { get => _lastId; set => _lastId = value; }

        bool _dbConnectionPersistence = false;
        public MySQLPersistence(bool dbConnectionPersistence = false)
        {
            _dbConnectionPersistence = dbConnectionPersistence;
            _connection = new MySqlConnection("Server = den1.mysql6.gear.host; Database = ecommercelp4; Uid = ecommercelp4; Pwd = @12345;");
            _cmd = _connection.CreateCommand();
        }

        public void Open()
        { 
            if(_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public void Close() { _connection.Close(); }

        public void StartTransaction()
        {
            Open();
            _trans = _connection.BeginTransaction();
            _cmd.Transaction = _trans;
        }

        public void TransactionCommit()
        {
            if(_trans != null)
            {
                _trans.Commit();
                _trans.Dispose();
                _trans = null;
            }
        }

        public void TransactionRollback()
        {
            if (_trans != null)
            {
                _trans.Rollback();
                _trans.Dispose();
                _trans = null;
            }
        }

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

            if(!_dbConnectionPersistence)
                Close();

            return qtnLinhasAfetadas;
        }

        public object ExecuteSelectScalar(string select, Dictionary<string, object> param = null)
        {
            object valor = null;

            Open();
            _cmd.CommandText = select;

            if (param != null)
            {
                foreach (var p in param)
                {
                    _cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
            }

            valor = _cmd.ExecuteScalar();

            if (!_dbConnectionPersistence)
                Close();

            return valor;
        }

        public DbDataReader ExecuteSelect(string select, Dictionary<string, object> param = null)
        {
            Open();
            _cmd.CommandText = select;

            if (param != null)
            {
                foreach (var p in param)
                {
                    _cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
            }

            /*
            //Tabela em memoria
            DataTable dt = new DataTable();
            dt.Load(_cmd.ExecuteReader());*/

            MySqlDataReader reader = _cmd.ExecuteReader();

            return reader;
        }

        public void CleanParam()
        {
            _cmd.Parameters.Clear();
        }
    }
}
