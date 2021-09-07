using FatihHAS1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FatihHAS1.Controllers
{   
    public class HomeController : Controller
    {       
        DataAccess.ProductEdit pro = new DataAccess.ProductEdit();

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(pro.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var dataProduct = pro.ListAll().Find(x => x.ProductId.Equals(ID));
            return Json(dataProduct, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Add(Product prop)
        {
            return Json(pro.ProductAdd(prop), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Product prop)
        {
            return Json(pro.ProductUpdate(prop), JsonRequestBehavior.AllowGet);
        }
    }
}