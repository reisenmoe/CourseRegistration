using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccess
{
    public static class SharedManager
    {
        public static KeunhongInstituteDBEntities cDBContext = new KeunhongInstituteDBEntities();

        public static void Update<T>(T target, params Expression<Func<T, object>>[] propertiesToUpdate) where T : class
        {
            try
            {
                cDBContext.Set<T>().Attach(target);

                //Flag the properties for updating
                foreach (var p in propertiesToUpdate)
                {
                    cDBContext.Entry(target).Property(p).IsModified = true;
                }

                cDBContext.Entry(target);
                cDBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
