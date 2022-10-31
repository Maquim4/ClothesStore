using ClothesStore.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel user)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credentional)
        {
            bool validUser;
            using (var connection=GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT*FROM USERS WHERE LOGIN=@login AND PASSWORD=@password";
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = credentional.UserName;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = credentional.Password;
                validUser=command.ExecuteScalar()==null?false:true;

            }
            return validUser;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(UserModel user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByLogin(string login)
        {
            UserModel user=null;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT*FROM USERS WHERE LOGIN=@login";
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                using ( var reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = (int)reader[0],
                            Login = reader[1].ToString(),
                            Password = string.Empty,
                            Role = reader[3].ToString()


                        
                        };
                        
                    }
                }

            }
            return user;
        }
    }
}
