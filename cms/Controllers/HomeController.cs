using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cms.Controllers
{
    public class HomeController : Controller
    {
        Mycmscontext db= new Mycmscontext();
        PageRepository pageRepository;
        public HomeController()
        {
            pageRepository = new PageRepository(db);
        }
        public ActionResult Index()
        {
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
        public ActionResult Slider()
        {
            return PartialView(pageRepository.PageSlider());
        }
    }
}