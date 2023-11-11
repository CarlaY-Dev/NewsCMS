using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace cms.Areas.admin.Controllers
{
    [Authorize]
    public class PageGroupsController : Controller
    {
        private IPageGroupRepository PageGroupRepository;
         Mycmscontext db=new Mycmscontext();
        public PageGroupsController()
        {
            PageGroupRepository= new PageGroupRepository(db);
        }
        // GET: admin/PageGroups
        public ActionResult Index()
        {
            return View(PageGroupRepository.GetAllGroups());
        }

        // GET: admin/PageGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = PageGroupRepository.PageGroupGetById(id.Value);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return View(pageGroup);
        }

        // GET: admin/PageGroups/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: admin/PageGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,GroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                PageGroupRepository.InsertGroup(pageGroup);
                PageGroupRepository.Save();
                return RedirectToAction("Index");
            }

            return View(pageGroup);
        }

        // GET: admin/PageGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = PageGroupRepository.PageGroupGetById(id.Value);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }

        // POST: admin/PageGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,GroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                PageGroupRepository.UpdateGroup(pageGroup);
                PageGroupRepository.Save();
                return RedirectToAction("Index");
            }
            return View(pageGroup);
        }

        // GET: admin/PageGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = PageGroupRepository.PageGroupGetById(id.Value);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }

        // POST: admin/PageGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           PageGroupRepository.DeleteGroup(id);
            PageGroupRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               PageGroupRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
