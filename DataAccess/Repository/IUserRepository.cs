using BusinessObject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetUserById(int accountId);
        void SignUpAccount(User newAccount, string confirmPassword);
        User Login(string username, string password);
        void Update(User account);
        void Insert(User account);
        void Remove(int id);

        bool EmailExists(string email);
        bool UsernameExists(string username);
    }
}
