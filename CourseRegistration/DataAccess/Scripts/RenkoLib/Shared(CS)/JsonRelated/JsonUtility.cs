using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleJSON;

namespace Renko
{
    public class JsonUtility
    {
        public static string Serialize(object instance, Type instanceType)
        {
            

            return null;
        }

        public static void Deserialize(string jsonStr, object instance, Type instanceType)
        {
            JSONNode root = JSON.Parse(jsonStr);
            
        }
    }
}
