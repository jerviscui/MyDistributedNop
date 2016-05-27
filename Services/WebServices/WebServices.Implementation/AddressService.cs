using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core;
using Core.Data;
using Core.Domain;
using Data;
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

        public AddressService()
        {
            _addressRepository = new EfRepository<Address>(new DataDbContext());
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
        public SerializedPage<Address> GetAddressesByPage(PageInfo pageInfo)
        {
            var query = _addressRepository.Table.Where(o => !o.IsDelete);
            var ordered = query.OrderBy(o => o.Id);

            return new SerializedPage<Address>(ordered, pageInfo.PageIndex, pageInfo.PageSize);
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

        /// <summary>
        /// Get all valid addresses
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Address>> GetAllAddressesAsync()
        {
            Console.WriteLine("GetAllAddressesAsync thread: " + Thread.CurrentThread.ManagedThreadId);
            var query = await _addressRepository.Table.Where(o => !o.IsDelete).ToListAsync();
            
            Console.WriteLine("GetAllAddressesAsync return thread: " + Thread.CurrentThread.ManagedThreadId);
            return query;
        }

        #endregion
    }
}
