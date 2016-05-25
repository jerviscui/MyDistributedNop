using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public class TypeFinder : ITypeFinder
    {
        /// <summary>
        /// Find classes of type from AppDomain
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isDefined">only search defined class</param>
        /// <returns></returns>
        public IEnumerable<Type> FindClassesOfType<T>(bool isDefined = true) where T : class
        {
            return FindClassesOfType<T>(AppDomain.CurrentDomain.GetAssemblies(), isDefined);
        }

        /// <summary>
        /// Find classes of type from assemblies
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblies"></param>
        /// <param name="isDefined">only search defined class</param>
        /// <returns></returns>
        public IEnumerable<Type> FindClassesOfType<T>(Assembly[] assemblies, bool isDefined = true) where T : class
        {
            return FindClassesOfType(typeof(T), assemblies);
        }

        /// <summary>
        /// Find classes of type from assemblyStrings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyStrings"></param>
        /// <param name="isDefined">only search defined class</param>
        /// <returns></returns>
        public IEnumerable<Type> FindClassesOfType<T>(string[] assemblyStrings, bool isDefined = true) where T : class
        {
            var assemblies = new List<Assembly>();
            try
            {
                foreach (var assemblyString in assemblyStrings)
                {
                    assemblies.Add(Assembly.Load(assemblyString));
                }
            }
            catch (Exception)
            {
                throw;
            }

            return FindClassesOfType(typeof(T), assemblies.ToArray(), isDefined);
        }

        /// <summary>
        /// Find classes of type from assemblies
        /// </summary>
        /// <param name="assginType"></param>
        /// <param name="assemblies"></param>
        /// <param name="isDefined">only search defined class</param>
        /// <returns></returns>
        public IEnumerable<Type> FindClassesOfType(Type assginType, Assembly[] assemblies, bool isDefined = true)
        {
            if (assemblies == null)
            {
                throw new ArgumentNullException("assemblies");
            }

            var resultTypes = new List<Type>();
            foreach (var assembly in assemblies)
            {
                Type[] types = null;
                try
                {
                    types = isDefined ? assembly.DefinedTypes.OfType<Type>().ToArray() : assembly.GetTypes();
                }
                catch (Exception)
                {
                    throw;
                }
                foreach (var type in types)
                {
                    if (type.IsClass && assginType.IsAssignableFrom(type))
                    {
                        resultTypes.Add(type);
                    }
                }
            }

            return resultTypes;
        }
    }
}
