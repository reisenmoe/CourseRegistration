/*

OTFTarget is an attribute used on variables in a class which can be assigned to, from object.

*/ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renko
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class OTFTarget : Attribute
    {
        public int iInx;

        public OTFTarget(int sortIndex)
        {
            iInx = sortIndex;
        }
    }
}
