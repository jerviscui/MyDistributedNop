using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Data;
using DataService.Interface;

namespace Web.Controllers
{
    public class TestController : BaseController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// 初始化 <see cref="T:System.Web.Mvc.Controller"/> 类的新实例。
        /// </summary>
        public TestController(IWorkContext workContext, IUserService userService) : base(workContext)
        {
            _userService = userService;
        }

        // GET: Test
        public ActionResult Index()
        {
            var user = _userService.GetUserByName("xiaoming");
            var roles = user.Roles;
            var address = user.Address;
            if (user != null)
            {
                ViewBag.Name = user.UserName;
            }

            return View();
        }
    }
}