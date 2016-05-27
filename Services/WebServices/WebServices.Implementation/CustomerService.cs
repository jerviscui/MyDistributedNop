using System.Linq;
using System.Runtime.InteropServices;
using Core;
using Core.Domain;
using WebServices.Interface;

namespace WebServices.Implementation
{
    public class CustomerService : ICustomerService
    {
        #region Fields

        private readonly IRepository<Customer> _customerRepository; 
        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion

        #region Properties

        #endregion

        #region Private

        #endregion

        #region Methods
        public Customer GetCustomerByUsername(string username)
        {
            return _customerRepository.Table.FirstOrDefault(o => o.Username.Equals(username));
        }
        #endregion
    }
}
