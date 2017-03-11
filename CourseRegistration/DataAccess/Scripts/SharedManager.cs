using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CourseRegistration
{
    public static class SharedManager
    {
        public static void Update<T>(T target, params Expression<Func<T, object>>[] propertiesToUpdate) where T : class
        {
            using (KeunhongInstituteDBEntities dbContext = new KeunhongInstituteDBEntities())
            {
                try
                {
                    dbContext.Set<T>().Attach(target);

                    //Flag the properties for updating
                    foreach (var p in propertiesToUpdate)
                    {
                        dbContext.Entry(target).Property(p).IsModified = true;
                    }

                    dbContext.Entry(target);
                    dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
