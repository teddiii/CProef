using CproefLib.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CproefLib.DAL
{
    /// <summary>
    /// Data Access Layer for Users
    /// </summary>
    public class DAL_Users
    {
        /// <summary>
        /// creates a new user in the database
        /// </summary>
        public static void Create(Users model)
        {
            var ctx = AppDbContext.Instance();

            ctx.Users.Add(model);
            ctx.SaveChanges();
        }

        /// <summary>
        /// updates the user in the database
        /// </summary>
        public static void Update(Users model)
        {
            var ctx = AppDbContext.Instance();

            ctx.Entry(model).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        /// <summary>
        /// gets the user from the database based on the username given (search)
        /// </summary>
        public static Users GetByUsername(string username)
        {
            var ctx = AppDbContext.Instance();

            return ctx.Users.SingleOrDefault(x => x.DeletedAt == null && x.Username.ToLower() == username.ToLower());
        }

        public static bool Any()
        {
            var ctx = AppDbContext.Instance();
            return ctx.Users.Any();
        }

        /// <summary>
        /// gets the currently logged in user
        /// </summary>
        /// <returns></returns>
        internal static Users GetCurrentUser()
        {
            var ctx = AppDbContext.Instance();
            return ctx.Users.SingleOrDefault(x => x.DeletedAt == null && x.Id == ctx.CurrentUserId);
        }

        /// <summary>
        /// gets a list of all users
        /// </summary>
        /// <returns></returns>
        public static List<Users> GetAll()
        {
            var ctx = AppDbContext.Instance();

            return ctx.Users
                            .Where(x => x.DeletedAt == null)
                            .ToList();
        }

        /// <summary>
        /// gets the email from the database based on the email given (search)
        /// </summary>
        public static Users GetByEmailAddress(string email)
        {
            var ctx = AppDbContext.Instance();

            //the u is een variabele die we gebruiken hier
            return ctx.Users.SingleOrDefault(u => u.DeletedAt == null && u.Email.ToLower() == email.ToLower());
        }

        internal static void SetAuthenticatedUser(Guid id)
        {
            var ctx = AppDbContext.Instance();
            ctx.CurrentUserId = id;
        }

        /// <summary>
        /// Sets the current user id null
        /// </summary>
        public static void Logout()
        {
            var ctx = AppDbContext.Instance();

            ctx.CurrentUserId = null;
        }
    }
}
