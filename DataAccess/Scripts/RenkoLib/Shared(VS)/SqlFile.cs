using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.IO;

namespace Renko
{
    /// <summary>
    /// A helper function for easily retrieving the sql command from an sql file.
    /// </summary>
    public class SqlFile
    {
        public static SqlCommand Read(SqlConnection connection, string path)
        {
            path = ServerDirectory.Get(ServerDirectory.CurrentDirectory, path);
            string cmd = File.ReadAllText(path);
            return new SqlCommand(cmd, connection);
        }
    }
}