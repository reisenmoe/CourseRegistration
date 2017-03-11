using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    #region User
    public static class UserManager
    {
        private static KeunhongInstituteDBEntities cDBContext
        { get { return SharedManager.cDBContext; } }

        
        public static User Create(User source)
        {
            //Create instance of new user and set values from source
            User user = new User();
            try
            {
                user.Address = source.Address;
                user.ContactNumber = source.ContactNumber;
                user.CreatedBy = source.CreatedBy;
                user.CreatedDateTime = DateTime.Now;
                user.DateOfBirth = source.DateOfBirth;
                user.Email = source.Email;
                user.FirstName = source.FirstName;
                user.FullName = source.FullName;
                user.IsActive = true;
                user.LastName = source.LastName;
                user.ModifiedBy = source.ModifiedBy;
                user.ModifiedDateTime = DateTime.Now;
                user.Password = source.Password;
                user.Student_ID = source.Student_ID;

                //Add the new user to DB and apply change
                cDBContext.Users.Add(user);
                cDBContext.SaveChanges();
            }
            catch(Exception ex)
            {
                return null;
            }
            return user;
        }
        public static void Delete(User user)
        {
            cDBContext.Users.Remove(user);
            cDBContext.SaveChanges();
        }
        
        public static User Login(string username, string password)
        {
            //Find a user with username and password
            return cDBContext.Users.FirstOrDefault(user => user.Student_ID.Equals(username) && user.Password.Equals(password));
        }
        public static User Exists(string username)
        {
            //Check if a user exists with given username and pw.
            return cDBContext.Users.FirstOrDefault(user => user.Student_ID.Equals(username));
        }
        public static RoleTypes GetRoleOf(User user)
        {
            var selection = cDBContext.User_Role.FirstOrDefault(u => u.User_ID == user.User_ID);
            return (RoleTypes)selection.Role_ID;
        }
    }
    #endregion

    #region Role
    public static class RoleManager
    {
        private static KeunhongInstituteDBEntities cDBContext
        { get { return SharedManager.cDBContext; } }


        public static List<Role> GetAllRoles()
        {
            return cDBContext.Roles.ToList();
        }
    }

    #region Extensions
    public static class RoleExtensions
    {
        public static RoleTypes GetRoleType(this Role context)
        {
            return (RoleTypes)context.Role_ID;
        }
    }
    #endregion
    #endregion

    #region User_Role
    public static class UserRoleManager
    {
        private static KeunhongInstituteDBEntities cDBContext
        { get { return SharedManager.cDBContext; } }


        public static User_Role Create(User_Role source)
        {
            User_Role ur = new User_Role();
            try
            {
                ur.CreatedBy = source.CreatedBy;
                ur.CreatedDateTime = DateTime.Now;
                ur.IsActive = true;
                ur.ModifiedBy = source.ModifiedBy;
                ur.ModifiedDateTime = DateTime.Now;
                ur.Role_ID = source.Role_ID;
                ur.User_ID = source.User_ID;

                cDBContext.User_Role.Add(ur);
                cDBContext.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return ur;
        }
    }

    #region Extensions
    public static class UserRoleExtensions
    {
        public static User GetUser(this User_Role context)
        {
            return SharedManager.cDBContext.Users.FirstOrDefault(u => u.User_ID.Equals(context.User_ID));
        }
        public static Role GetRole(this User_Role context)
        {
            return SharedManager.cDBContext.Roles.FirstOrDefault(r => r.Role_ID.Equals(context.Role_ID));
        }
    }
    #endregion
    #endregion
}
