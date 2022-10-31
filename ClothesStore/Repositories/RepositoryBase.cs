using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ClothesStore.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connection;
        public RepositoryBase()
        {
            _connection = "SERVER = localhost; DATABASE=clothes_store; UID=root;PASSWORD=1999o9o9oDeoxs; ";
        }
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connection);
        }


    }
}
