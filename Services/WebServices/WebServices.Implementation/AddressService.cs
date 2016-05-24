using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Data;
using Core.Domain;
using WebServices.Interface;

namespace WebServices.Implementation
{
    public class AddressService : IAddressService
    {
        #region Fields

        private readonly IRepository<Address> _addressRepository;
        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public AddressService(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add a new address
        /// </summary>
        /// <param name="entity"></param>
        public void Add(Address entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _addressRepository.Insert(entity);
        }

        /// <summary>
        /// Get addresses by page
        /// </summary>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public IPagedList<Address> GetAllAddresses(IPageInfo pageInfo)
        {
            var query = _addressRepository.Table.Where(o => !o.IsDelete);
            
            return new PagedList<Address>(query, pageInfo.PageIndex, pageInfo.PageSize);
        }

        /// <summary>
        /// Get all valid addresses
        /// </summary>
        /// <returns></returns>
        public IList<Address> GetAllAddresses()
        {
            var query = _addressRepository.Table.Where(o => !o.IsDelete);

            return query.ToList();
        }
        #endregion
    }
}
