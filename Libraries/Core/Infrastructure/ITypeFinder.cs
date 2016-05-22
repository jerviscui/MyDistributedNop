using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public interface ITypeFinder
    {
        /// <summary>
        /// Find classes of type from AppDomain
        /// </summary>
        /// <returns></returns>
        IEnumerable<Type> FindClassesOfType<T>() where T : class;
    }
}
