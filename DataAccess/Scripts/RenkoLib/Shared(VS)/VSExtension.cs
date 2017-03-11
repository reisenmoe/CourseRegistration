using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace Renko
{
    /// <summary>
    /// Just a class for implementing extension functions
    /// </summary>
    public static class VSExtension
    {
        #region SqlCommand
        public static void MatchParameter(this SqlCommand cmd, string key, string val)
        {
            if (!key.StartsWith("@"))
                key = "@" + key;

            cmd.Parameters.AddWithValue(key, val);
        }
        public static void MatchParameter(this SqlCommand cmd, string key, int val)
        {
            if (!key.StartsWith("@"))
                key = "@" + key;

            cmd.Parameters.AddWithValue(key, val);
        }
        public static void MatchParameter(this SqlCommand cmd, string key, bool val)
        {
            if (!key.StartsWith("@"))
                key = "@" + key;

            cmd.Parameters.AddWithValue(key, val);
        }
        public static void MatchParameter(this SqlCommand cmd, string key, object val)
        {
            if (!key.StartsWith("@"))
                key = "@" + key;

            cmd.Parameters.AddWithValue(key, val);
        }
        #endregion
    }
}