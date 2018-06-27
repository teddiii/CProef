using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CproefLib.Entities;
using CproefLib.Utilities;
using CproefLib.DAL;
using CproefLib.Models;

namespace CproefLib.BL
{
    /// <summary>
    /// The business logic for the user handling
    /// </summary>
    public class BL_Users
    {
        /// <summary>
        /// gets the user by its username
        /// </summary>
        /// <param name="username"></param>
        public static Users GetByUsername(string username)
        {
            try
            {
                return DAL_Users.GetByUsername(username);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// returns the authenticated user
        /// </summary>
        public static Users GetCurrentUser()
        {
            try
            {
                return DAL_Users.GetCurrentUser();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// returns a list of all users
        /// </summary>
        public static List<Users> GetAll()
        {
            try
            {
                return DAL_Users.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// save the created user
        /// </summary>
        /// <param name="model"></param>
        public static bool Save(Users model)
        {
            try
            {
                if (model.IsNew())
                    Create(model);
                else
                    Update(model);

            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }

        /// <summary>
        /// gets the user by its email
        /// </summary>
        /// <param name="email"></param>
        public static Users GetByEmailAddress(string email)
        {
            try
            {
                return DAL_Users.GetByEmailAddress(email);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Deletes the user
        /// </summary>
        /// <param name="model"></param>
        public static void Delete(Users model)
        {
            try
            {
                model.DeletedAt = DateTime.Now;
                Save(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// the order by which it gets the login info
        /// </summary>
        /// <param name="login"></param>
        public static Users Get(string login)
        {
            try
            {
                if (login.IsEmailAddress())
                {
                    return GetByEmailAddress(login);
                }
                else
                {
                    return GetByUsername(login);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// creates a new user
        /// </summary>
        /// <param name="user"></param>
        public static void Create(Users user)
        {
            try
            {
                if (user.Id == Guid.Empty)
                    user.Id = Guid.NewGuid();

                DAL_Users.Create(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// this updates the given user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        public static void Update(Users user, string pwd = null)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(pwd))
                {
                    user = ChangePassword(user, pwd);
                }

                DAL_Users.Update(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// the method where we change the password of the user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        public static Users ChangePassword(Users user, string pwd)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pwd))
                    pwd = StringExtensions.GetRandomString(8);

                var _salt = SecurityExtensions.GetSalt();

                var _encryptedPwd = SecurityExtensions.Encrypt(pwd + _salt.ToString());

                user.Salt = _salt.ToString();
                user.Password = _encryptedPwd;

                return user;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void SendCredentials(string firstname, string lastname, string email, string username, string pwd)
        {
            string subject = "Your credentials for Login in";
            StringBuilder message = new StringBuilder();
            message.AppendLine($"Dear {firstname} {lastname}");
            message.AppendLine("");
            message.AppendLine("Here are your new credentials for the application. It's possible you automatically will be forwarded to your account page. In here you can change the password if you fill in the passwordfield");
            message.AppendLine($"User name: {username}");
            message.AppendLine($"Password: {pwd}");
            message.AppendLine("");
            message.AppendLine("Kind regard");
            message.AppendLine("Your administrator");

            BL_Mailing.SendMail(firstname + " " + lastname, email, subject, message.ToString());

        }

        /// <summary>
        /// Checks wether the login info matches the given credentials
        /// </summary>
        /// <param name="loginModel"></param>
        public static bool Authenticate(Loginmodel loginModel)
        {
            try
            {
                // 01. Check if the user exists
                var _user = Get(loginModel.CredentialName);

                if (_user == null)
                {
                    throw new UserNotFoundException(loginModel.CredentialName);
                }

                var encrypted = SecurityExtensions.Encrypt(loginModel.Password + _user.Salt);

                if (_user.Password == encrypted)
                {
                    DAL_Users.SetAuthenticatedUser(_user.Id);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

         /// <summary>
         /// Logging the current user out
         /// </summary>
         public static void Logout()
         {
             try
             {
                 DAL_Users.Logout();
             }
             catch (Exception)
             {

                 throw;
             }
         }

         public static bool Any()
         {
             try
             {
                 return DAL_Users.Any();
             }
             catch (Exception)
             {

                 throw;
             }
         }
     
    }
}
