using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renko;

namespace CourseRegistration
{
    public static class FacultyManager
    {
        public static Faculty Create(Faculty source)
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                Faculty faculty = new Faculty();
                try
                {
                    faculty.CreatedBy = source.CreatedBy;
                    faculty.CreatedDateTime = DateTime.Now;
                    faculty.Faculty_Name = source.Faculty_Name;
                    faculty.IsActive = true;
                    faculty.ModifiedBy = source.ModifiedBy;
                    faculty.ModifiedDateTime = DateTime.Now;

                    dbContext.Faculties.Add(faculty);
                    dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    return null;
                }
                return faculty;
            }
        }

        public static List<Faculty> GetAll()
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                return dbContext.Faculties.ToList();
            }
        }
    }
    
    #region Extensions
    public static class FacultyExtensions
    {

    }
    #endregion
}
