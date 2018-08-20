using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.attributes
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =false,Inherited =false)]
    public class ReflectionInvocationAttribute:Attribute
    {
        private bool _disabled;
        public bool Disabled
        {
            get { return _disabled; }
        }

        private string _user;
        public string DisabledByUser
        {
            get { return _user; }
            set { _user = value; }
        }


        public ReflectionInvocationAttribute(bool disable)
        {
            this._disabled = disable;
        }
    }
}
