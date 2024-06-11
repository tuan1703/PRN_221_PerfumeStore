using BusinessObject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class UserDAO
    {
        private static UserDAO instance = null;
        private static readonly object instanceLock = new object();
        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }


        public User GetUserByID(int userId)
        {
            User user = null;
            try
            {
                using var context = new PerfumesStoreContext();
                user = context.Users.SingleOrDefault(a => a.UserId == userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public void RegisterAccount(User newAccount, string confirmPassword)
        {
            try
            {
                using (var context = new PerfumesStoreContext())
                {
                    // Check if the username is already taken
                    var existingUsername = context.Users.FirstOrDefault(a => a.Username == newAccount.Username);
                    if (existingUsername != null)
                    {
                        throw new Exception("Username is already taken");
                    }

                    // Check if the email is already in use
                    var existingEmail = context.Users.FirstOrDefault(a => a.Email == newAccount.Email);
                    if (existingEmail != null)
                    {
                        throw new Exception("Email is already in use");
                    }

                    // Ensure password and confirm password match
                    if (newAccount.Password != confirmPassword)
                    {
                        throw new Exception("Password and confirm password do not match");
                    }
                    if (newAccount.FullName == null)
                    {
                        throw new Exception("Name can not be blank!");
                    }

                    // All validations passed, add the new account
                    context.Users.Add(newAccount);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<User> GetAllAccount()
        {
            using var context = new PerfumesStoreContext();
            List<User> accounts = context.Users.ToList();
            return accounts;
        }


        public int GetAccountIdByLogin(string username, string password)
        {
            int accountId = -1;

            try
            {
                using (var context = new PerfumesStoreContext())
                {
                    User account = context.Users.FirstOrDefault(a => a.Username == username && a.Password == password);

                    if (account != null)
                    {

                        accountId = account.UserId;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return accountId;
        }


        public User Login(string username, string password)
        {
            User? account = null;
            try
            {


                using var context = new PerfumesStoreContext();

                account = context.Users.SingleOrDefault(a => a.Username == username && a.Password == password);
                if (account == null)
                {
                    throw new Exception("Login failed! Please check your email and password!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

        public void UpdateAccount(User account)
        {
            if (GetUserByID(account.UserId) == null)
            {
                throw new Exception("Account doesn't exist!");
            }
            using var context = new PerfumesStoreContext();
            context.Users.Update(account);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            User account = GetUserByID(id);
            if (account == null)
            {
                throw new Exception("Account doesn't exist!");
            }
            using var context = new PerfumesStoreContext();
            context.Users.Remove(account);
            context.SaveChanges();
        }

        public void AddNew(User account)
        {

            using var context = new PerfumesStoreContext();
            context.Users.Add(account);
            context.SaveChanges();
        }

        public bool EmailExists(string email)
        {
            using var context = new PerfumesStoreContext();

            return context.Users.Any(a => a.Email == email);
        }

        public bool UsernameExists(string username)
        {
            using var context = new PerfumesStoreContext();
            return context.Users.Any(a => a.Username == username);
        }
    }
}
