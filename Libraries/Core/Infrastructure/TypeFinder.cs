﻿using System;
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
        /// <returns></returns>
        public IEnumerable<Type> FindClassesOfType<T>() where T : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Find classes of type from assemblies
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Type> FindClassesOfType<T>(Assembly[] assemblies) where T : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Find classes of type from assemblies
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Type> FindClassesOfType<T>(string[] assemblies) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
