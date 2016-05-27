using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Core.Data;
using Web.Framework;
using WebServices.Interface;

namespace Web.Controllers
{
    public class TestAsyncController : BaseAsyncController
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userWcfService;

        private readonly DataService.Interface.IUserService _userService;

        #region Ctor
        /// <summary>
        /// 初始化 <see cref="T:System.Web.Mvc.AsyncController"/> 类的新实例。
        /// </summary>
        public TestAsyncController(IWorkContext workContext, IAddressService addressService, IUserService userWcfService, DataService.Interface.IUserService userService) : base(workContext)
        {
            _addressService = addressService;
            _userWcfService = userWcfService;
            _userService = userService;
        }
        #endregion

        // GET: TestAsync
        public async Task<ActionResult> Index()
        {
            var user = await _userService.GetUserByNameAsync("xiaoming");
            ViewBag.User = user;

            return View();
        }

        public async Task<ActionResult> Async()
        {
            await Task.Delay(1000);
            int count = 0;
            count = await Task.Run(() => count + 1);

            ViewBag.Count = count;

            return View("Index");
        }

        public async Task<ActionResult> AsyncWcf()
        {
            var addresses = await _addressService.GetAllAddressesAsync();

            var user = await _userWcfService.GetUserByNameAsync("xiaoming");
            ViewBag.User = user.UserName;

            return View(addresses);
        }
    }
}