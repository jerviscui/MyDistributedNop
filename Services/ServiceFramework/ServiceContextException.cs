using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceFramework
{
    public class ServiceContextException : Exception
    {
        public ServiceContextException() : base("A terrible mistake! Must stop!")
        {
            //todo: insert error list? and create a aop check error event?
        }
    }
}
