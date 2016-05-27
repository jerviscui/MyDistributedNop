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
    public class CustomerServiceProxy : ICustomerService
    {
        #region Fields

        private readonly Proxy<ICustomerService> _customerProxy;
        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public CustomerServiceProxy(Proxy<ICustomerService> customerProxy)
        {
            _customerProxy = customerProxy;
        }
        #endregion

        #region Properties

        #endregion

        #region Private

        #endregion

        #region Methods
        public Customer GetCustomerByUsername(string username)
        {
            return _customerProxy.Client.GetCustomerByUsername(username);
        }
        #endregion
    }
}
