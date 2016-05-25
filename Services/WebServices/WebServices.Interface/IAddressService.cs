using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Core.Data;
using Core.Domain;

namespace WebServices.Interface
{
    [ServiceContract]
    public interface IAddressService
    {
        /// <summary>
        /// Add a new address
        /// </summary>
        /// <param name="entity"></param>
        [OperationContract]
        void Add(Address entity);

        /// <summary>
        /// Get addresses by page
        /// </summary>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        [OperationContract]
        IPagedList<Address> GetAddressesByPage(IPageInfo pageInfo);

        /// <summary>
        /// Get all valid addresses
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<Address> GetAllAddresses();
    }
}
