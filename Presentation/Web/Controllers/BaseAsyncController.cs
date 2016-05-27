using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Data;

namespace Web.Controllers
{
    /// <summary>
    /// The base controller for Async
    /// </summary>
    public class BaseAsyncController : AsyncController
    {
        protected IWorkContext WorkContext;
        
        /// <summary>
        /// 初始化 <see cref="T:System.Web.Mvc.AsyncController"/> 类的新实例。
        /// </summary>
        public BaseAsyncController(IWorkContext workContext)
        {
            WorkContext = workContext;
        }
    }
}