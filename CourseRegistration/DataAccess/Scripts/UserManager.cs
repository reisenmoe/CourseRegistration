using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistration
{
    #region User
    public static class UserManager
    {
        public static User Create(User source)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
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
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    return null;
                }
                return user;
            }
        }
        public static void Delete(User user)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }
        
        public static User Login(string username, string password)
        {
            password = Renko.MD5Encryption.Encrypt(password);

            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Users.FirstOrDefault(user => user.Student_ID.Equals(username) && password.Equals(user.Password) && user.IsActive);
            }
        }
        public static User Exists(string username)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                //Check if a user exists with given username and pw.
                return dbContext.Users.FirstOrDefault(user => user.Student_ID.Equals(username) && user.IsActive);
            }
        }
        public static RoleTypes GetRoleOf(User user)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                var selection = dbContext.User_Role.FirstOrDefault(u => u.User_ID == user.User_ID);
                return (RoleTypes)selection.Role_ID;
            }
        }

        public static List<User> GetAllUsers()
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Users.Where(u => u.IsActive).ToList();
            }
        }
        public static List<User> GetAllUsers(RoleTypes roleType)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                var roles = dbContext.User_Role.Where(r => r.Role_ID == (decimal)roleType);

                List<User> users = new List<User>();
                foreach(User_Role role in roles)
                {
                    users.Add(role.GetUser());
                }

                return users;
            }
        }

    }

    public static class UserExtensions
    {
        public static bool IsEnrolled(this User context, Course_Schedule schedule)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Student_Course.FirstOrDefault(c => c.CourseSchedule_ID.Equals(schedule.CourseSchedule_ID)) != null;
            }
        }
        public static bool IsEnrolled(this User context, Course course)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Student_Course.FirstOrDefault(c => c.GetCourse().Course_ID.Equals(course.Course_ID)) != null;
            }
        }

        public static bool HasStudentCourse(this User context, Course_Schedule schedule)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Student_Course.FirstOrDefault(sc => sc.User_ID.Equals(context.User_ID) && sc.CourseSchedule_ID.Equals(schedule.CourseSchedule_ID)) != null;
            }
        }
        public static Student_Course GetStudentCourse(this User context, Course_Schedule schedule)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Student_Course.FirstOrDefault(sc => sc.User_ID.Equals(context.User_ID) && sc.CourseSchedule_ID.Equals(schedule.CourseSchedule_ID));
            }
        }
    }
    #endregion

    #region Role
    public static class RoleManager
    {
        public static List<Role> GetAllRoles()
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Roles.ToList();
            }
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
        public static User_Role Create(User_Role source)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
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

                    dbContext.User_Role.Add(ur);
                    dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    return null;
                }
                return ur;
            }
        }
    }

    #region Extensions
    public static class UserRoleExtensions
    {
        public static User GetUser(this User_Role context)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Users.FirstOrDefault(u => u.User_ID.Equals(context.User_ID));
            }
        }
        public static Role GetRole(this User_Role context)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Roles.FirstOrDefault(r => r.Role_ID.Equals(context.Role_ID));
            }
        }
    }
    #endregion
    #endregion
}
