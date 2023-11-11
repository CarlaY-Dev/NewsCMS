using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Globalization;
using System.Web.Mvc;
using DataLayer;
using System.Web.UI;

namespace cms.Areas.admin.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        private IPageRepository pageRepository;
        private IPageGroupRepository pageGroupRepository;
        private Mycmscontext db = new Mycmscontext();
        public PagesController()
        {
            pageRepository = new PageRepository(db);
            pageGroupRepository = new PageGroupRepository(db);
        }
        // GET: admin/Pages
        public ActionResult Index()
        {

            return View(pageRepository.GetAllPages());
        }

        // GET: admin/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataLayer.Page page = db.Page.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAllGroups(), "GroupID", "GroupTitle");
            return View();
        }

        // POST: admin/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageID,GroupID,Title,ShortDescription,Text,Visit,ImageName,ShowInSlider,CerateDate,Tags")] DataLayer.Page page, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {

                if (imgUp != null)
                {
                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/pageImages/" + page.ImageName));
                }
                page.CerateDate = DateTime.Now;
                page.Visit = 0;
                pageRepository.InsertPage(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAllGroups(), "GroupID", "GroupTitle");
            return View(page);
        }

        // GET: admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataLayer.Page page = pageRepository.PageGetById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAllGroups(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // POST: admin/Pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageID,GroupID,Title,ShortDescription,Text,Visit,ImageName,ShowInSlider,CerateDate,Tags")] DataLayer.Page page, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    if (page.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/pageImages/"+ page.ImageName));
                    }
                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/pageImages/" + page.ImageName));
                }
                pageRepository.UpdatePage(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.PageGroup, "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var page = pageRepository.PageGetById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var page = pageRepository.PageGetById(id); 
            if (page.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/pageImages/" + page.ImageName));
            }
            pageRepository.DeletePage(page);
            pageRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

                pageGroupRepository.Dispose();
                pageRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
