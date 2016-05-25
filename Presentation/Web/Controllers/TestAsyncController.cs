using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class TestAsyncController : AsyncController
    {
        // GET: TestAsync
        public ActionResult Index()
        {
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
    }
}