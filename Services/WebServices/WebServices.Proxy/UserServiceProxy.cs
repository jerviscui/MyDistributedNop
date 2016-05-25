using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using WebServices.Interface;
using WcfTools;

namespace WebServices.Proxy
{
    public class UserServiceProxy : IUserService
    {
        #region Fields
        private readonly Proxy<IUserService> _proxy;
        #endregion

        #region Ctor

        public UserServiceProxy()
        {
            _proxy = new ProxyManager().GetProxy<IUserService>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserById(int id)
        {
            return _proxy.Client.GetUserById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User GetUserByName(string name)
        {
            return _proxy.Client.GetUserByName(name);
        }
        #endregion
    }
}
