﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Data;

namespace Web.Controllers
{
    /// <summary>
    /// The base controller class
    /// </summary>
    public abstract class BaseController : Controller
    {
        protected IWorkContext WorkContext;

        /// <summary>
        /// 初始化 <see cref="T:System.Web.Mvc.Controller"/> 类的新实例。
        /// </summary>
        protected BaseController(IWorkContext workContext)
        {
            WorkContext = workContext;
        }
    }
}