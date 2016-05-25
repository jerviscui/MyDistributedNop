using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public interface ITypeFinder
    {
        /// <summary>
        /// Find classes of type from AppDomain
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isDefined">only search defined class</param>
        /// <returns></returns>
        IEnumerable<Type> FindClassesOfType<T>(bool isDefined = true) where T : class;

        /// <summary>
        /// Find classes of type from assemblies
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblies"></param>
        /// <param name="isDefined">only search defined class</param>
        /// <returns></returns>
        IEnumerable<Type> FindClassesOfType<T>(Assembly[] assemblies, bool isDefined = true) where T : class;

        /// <summary>
        /// Find classes of type from assemblyStrings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyStrings"></param>
        /// <param name="isDefined">only search defined class</param>
        /// <returns></returns>
        IEnumerable<Type> FindClassesOfType<T>(string[] assemblyStrings, bool isDefined = true) where T : class;

        /// <summary>
        /// Find classes of type from assemblies
        /// </summary>
        /// <param name="assginType"></param>
        /// <param name="assemblies"></param>
        /// <param name="isDefined">only search defined class</param>
        /// <returns></returns>
        IEnumerable<Type> FindClassesOfType(Type assginType, Assembly[] assemblies, bool isDefined = true);
    }
}
