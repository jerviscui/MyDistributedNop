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
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public UserServiceProxy(Proxy<IUserService> proxy)
        {
            _proxy = proxy;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<User> GetUserByNameAsync(string name)
        {
            return _proxy.Client.GetUserByNameAsync(name);
        }

        #endregion
    }
}
