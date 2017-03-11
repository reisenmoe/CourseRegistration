using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//This macro is declared so my class wouldn't make conflict
//with the Debug class in System.Diagnostics namespace.
using DBG = System.Diagnostics.Debug;

namespace Renko
{
    /// <summary>
    /// A helper function for logging out informations to the console
    /// </summary>
    public class Debug
    {
        public static void Log(object val)
        {
            DBG.WriteLine("Debug.Log: " + val.ToString());
        }
        public static void LogWarning(object val)
        {
            DBG.WriteLine("Debug.LogWarning: " + val.ToString());
        }
        public static void LogError(object val)
        {
            DBG.WriteLine("Debug.LogError: " + val.ToString());
        }
    }
}