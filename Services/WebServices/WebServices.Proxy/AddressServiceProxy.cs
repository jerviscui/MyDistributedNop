using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;
using Core.Domain;
using WebServices.Interface;
using WcfTools;

namespace WebServices.Proxy
{
    public class AddressServiceProxy : IAddressService
    {
        private readonly Proxy<IAddressService> _proxy;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public AddressServiceProxy(Proxy<IAddressService> proxy)
        {
            _proxy = proxy;
        }

        public AddressServiceProxy()
        {
            _proxy = new ProxyManager().GetProxy<IAddressService>();
        }

        /// <summary>
        /// Add a new address
        /// </summary>
        /// <param name="entity"></param>
        public void Add(Address entity)
        {
            _proxy.Client.Add(entity);
        }

        /// <summary>
        /// Get addresses by page
        /// </summary>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public IPagedList<Address> GetAddressesByPage(IPageInfo pageInfo)
        {
            return _proxy.Client.GetAddressesByPage(pageInfo);
        }

        /// <summary>
        /// Get all valid addresses
        /// </summary>
        /// <returns></returns>
        public IList<Address> GetAllAddresses()
        {
            return _proxy.Client.GetAllAddresses();
        }
    }
}
