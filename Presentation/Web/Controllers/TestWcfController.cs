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

        public TestWcfController()
        {
            _addressService = new AddressServiceProxy();
            _userService = new UserServiceProxy();
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