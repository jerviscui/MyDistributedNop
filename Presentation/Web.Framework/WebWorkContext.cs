using System;
using System.Web;
using Core.Data;
using Core.Domain;
using WebServices.Interface;

namespace Web.Framework
{
    public class WebWorkContext : IWorkContext
    {
        #region Fields

        private readonly HttpContextBase _httpContext;
        private readonly ICustomerService _customerService;

        private Customer _customer;

        private const string UserCookie = "MyDistributedNop.Customer";
        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public WebWorkContext(HttpContextBase httpContext, ICustomerService customerService)
        {
            _httpContext = httpContext;
            _customerService = customerService;
        }
        #endregion

        #region Properties

        public Customer CurrentCustomer
        {
            get
            {
                if (_customer != null)
                {
                    return _customer;
                }
                var cookie = GetCookie();
                if (cookie != null)
                {
                    var customer = _customerService.GetCustomerByUsername(cookie.Value);
                    if (customer != null)
                    {
                        return (_customer = customer);
                    }
                }
                return null;
            }
            set
            {
                _customer = value;
                SetUserCookie(value.Username);
            }
        }

        #endregion

        #region Ulitities

        protected virtual HttpCookie GetCookie()
        {
            if (_httpContext != null && _httpContext.Request != null)
            {
                return _httpContext.Request.Cookies[UserCookie];
            }

            return null;
        }

        protected virtual void SetUserCookie(string username)
        {
            if (_httpContext != null && _httpContext.Response != null)
            {
                var cookie = new HttpCookie(UserCookie);
                cookie.Value = username;
                if (username == string.Empty)
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddDays(7);
                }

                _httpContext.Response.Cookies.Add(cookie);
            }
        }
        #endregion

        #region Methods

        #endregion
    }
}
