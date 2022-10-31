using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Model
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credentional);
        void Add(UserModel user);
        void Edit(UserModel user);
        bool Delete(int id);
        UserModel GetById(int id);
        UserModel GetByLogin(string login);
        IEnumerable<UserModel> GetAll();
    }
}
