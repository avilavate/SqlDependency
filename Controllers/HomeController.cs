using Notifications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Notifications.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            NotificationRepo objRepo = new NotificationRepo();
            var result = objRepo.GetData();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}