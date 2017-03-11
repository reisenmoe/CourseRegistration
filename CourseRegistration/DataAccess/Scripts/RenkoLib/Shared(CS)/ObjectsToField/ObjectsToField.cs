using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Renko
{
    public class ObjectsToField
    {
        public static void Set(object[] source, object targetInstance, Type instanceType)
        {
            #region Property infos
            //Get all property infos in this type
            PropertyInfo[] properties = instanceType.GetProperties();
            //For each infos in the array
            for (int i = 0; i < properties.Length; i++)
            {
                //Try getting the OTFTarget instance
                OTFTarget attrInstance = Attribute.GetCustomAttribute(properties[i], typeof(OTFTarget)) as OTFTarget;
                //If not null
                if(attrInstance != null)
                {
                    //Set value to this property
                    properties[i].SetValue(targetInstance, source[attrInstance.iInx]);
                }
            }
            #endregion

            #region Field infos
            //Get all field infos in this type
            FieldInfo[] fields = instanceType.GetFields();
            //For each infos in the array
            for (int i = 0; i < fields.Length; i++)
            {
                //Try getting the OTFTarget instance
                OTFTarget attrInstance = Attribute.GetCustomAttribute(fields[i], typeof(OTFTarget)) as OTFTarget;
                //If not null
                if (attrInstance != null)
                {
                    //Set value to this property
                    fields[i].SetValue(targetInstance, source[attrInstance.iInx]);
                }
            }
            #endregion
        }
    }
}
