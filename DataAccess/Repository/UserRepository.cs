using BusinessObject.Object;
using DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        public User GetUserById(int accountId) => UserDAO.Instance.GetUserByID(accountId);



        public IEnumerable<User> GetAll() => UserDAO.Instance.GetAllAccount();

        public void Insert(User account) => UserDAO.Instance.AddNew(account);

        public User Login(string username, string password) => UserDAO.Instance.Login(username, password);



        public void Remove(int id) => UserDAO.Instance.Delete(id);

        public void SignUpAccount(User newAccount, string confirmPassword) => UserDAO.Instance.RegisterAccount(newAccount, confirmPassword);

        public void Update(User account) => UserDAO.Instance.UpdateAccount(account);

        public bool UsernameExists(string username) => UserDAO.Instance.UsernameExists(username);
        public bool EmailExists(string email) => UserDAO.Instance.EmailExists(email);
    }
}
