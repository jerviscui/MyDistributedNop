using System.Linq;
using System.Web.Mvc;
using Core.Data;
using WebServices.Interface;
using WebServices.Proxy;

namespace Web.Controllers
{
    public class TestWcfController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;
        
        /// <summary>
        /// 初始化 <see cref="T:System.Web.Mvc.Controller"/> 类的新实例。
        /// </summary>
        public TestWcfController(IAddressService addressService, IUserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }

        // GET: TestWcf
        public ActionResult Index()
        {
            var list = _addressService.GetAllAddresses();
            var page = _addressService.GetAddressesByPage(new PageInfo(0, 10));

            var user = _userService.GetUserByName("xiaoming");

            var roles = user.Roles;
            var address = user.Address;

            ViewBag.Addresses = list.Select(o => o.City);

            return View();
        }
    }
}