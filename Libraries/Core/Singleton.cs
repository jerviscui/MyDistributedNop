using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Singleton
    {
        static Singleton()
        {
            _singletons = new Dictionary<Type, object>();
        }

        private static readonly Dictionary<Type, object> _singletons;

        public static Dictionary<Type, object> AllSingleton
        {
            get
            {
                return _singletons;
            }
        }
    }

    public class Singleton<T> : Singleton
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                return _instance;
            }
            set
            {
                _instance = value;
                AllSingleton[typeof(T)] = _instance;
            }
        }
    }
}
