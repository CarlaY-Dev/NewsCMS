using DataLayer;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cms.Controllers
{
    public class SearchController : Controller
    {
        IPageRepository pageRepository;
        Mycmscontext db=new Mycmscontext();
        public SearchController()
        {
            pageRepository = new PageRepository(db);
        }
        // GET: Search
        public ActionResult Index(string q)
        {
            ViewBag.Name = q;

            return View(pageRepository.SearchPage(q));
        }
    }
}