using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WcfTools
{
    public class ProxyManager
    {
        #region Fields

        private const string ProxyKey = "";
        private static Dictionary<Type, object> _allProxies;

        #endregion

        #region Ctor

        static ProxyManager()
        {
            _allProxies = new Dictionary<Type, object>();
        }
        #endregion

        #region Properties

        public Dictionary<Type, object> Proxies
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return _allProxies;
                }
                else
                {
                    var context = HttpContext.Current;
                    if (context.Items[ProxyKey] == null)
                    {
                        context.Items[ProxyKey] = new Dictionary<Type, object>();
                    }

                    return (Dictionary<Type, object>)context.Items[ProxyKey];
                }
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Get proxy of the <see cref="T:System.Object"/> class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Proxy<T> GetProxy<T>() where T : class
        {
            if (Proxies == null)
            {
                throw new Exception("ProxyManager init failed.");
            }

            object proxy;
            var type = typeof(T);
            if (Proxies.ContainsKey(type))
            {
                proxy = Proxies[type];
            }
            else
            {
                proxy = new Proxy<T>(type.Name);
                Proxies[type] = proxy;
            }

            var returnProxy = proxy as Proxy<T>;
            if (returnProxy == null)
            {
                throw new Exception("Proxy init failed.");
            }

            returnProxy.Open();
            return returnProxy;
        }
        #endregion
    }
}
