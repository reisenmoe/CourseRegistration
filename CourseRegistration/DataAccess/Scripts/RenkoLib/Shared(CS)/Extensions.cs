using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renko
{
    public static class Extensions
    {

        #region String
        public static bool ContainsIgnoreCase(this string context, string target)
        {
            return context.ToLower().Contains(target.ToLower());
        }
        public static bool EqualsIgnoreCase(this string context, string target)
        {
            return context.ToLower().Equals(target.ToLower());
        }
        #endregion
    }
}
