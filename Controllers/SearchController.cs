using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FatihHAS1.Models;

namespace FatihHAS1.Controllers
{
    public class SearchController : Controller
    {
        DataAccess.SearchAccess pro = new DataAccess.SearchAccess();
        // GET: Search
        public JsonResult List(Product p)
        {
            return Json(pro.Search(p), JsonRequestBehavior.AllowGet);
        }
    }
}