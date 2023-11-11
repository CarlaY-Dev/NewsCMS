using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cms.Controllers
{
    public class NewsController : Controller
    {
        Mycmscontext db=new Mycmscontext();
        IPageGroupRepository pageGroupRepository;
        IPageRepository pageRepository;
        IPageCommentRepository pageCommentRepository;
        public NewsController()
        {
            pageRepository = new PageRepository(db);
            pageGroupRepository= new PageGroupRepository(db);
            pageCommentRepository= new PageCommentRepositroy(db);
        }
        // GET: News
        public ActionResult showGroups()
        {
            return PartialView(pageGroupRepository.GetGroupsForView());
        }

        public ActionResult ShowGroupsInMenu() 
        {
            return PartialView(pageGroupRepository.GetAllGroups());
        }
        public ActionResult ShowTopNews() 
        {
            return PartialView(pageRepository.TopNews());
        }
        public ActionResult ShowLatestNews() 
        {
            return PartialView(pageRepository.LastNews());
        }
        [Route("Archive")]
        public ActionResult Archive() 
        {
            return View(pageRepository.GetAllPages());
        }
        [Route("Groups/{id}/{title}")]
        public ActionResult ShowGroupByPage(int id,string title)
        {
            ViewBag.Name = title;
            return View(pageRepository.ShowPagesByGroup(id));
        }
        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var news=pageRepository.PageGetById(id);
            if(news==null) { return HttpNotFound(); }
            news.Visit += 1;
            pageRepository.UpdatePage(news);
            pageRepository.Save();
            return View(news);
        }
        public ActionResult AddComment(int id,string name, string email, string comment)
        {
            PageComment Cmnt = new PageComment()
            {
                CreateDate = DateTime.Now,
                PageID = id,
                Comment = comment,
                Name= name,
                Email=email
            };
            pageCommentRepository.AddPageComment(Cmnt);
            return PartialView("ShowComments", pageCommentRepository.getCommentByNewsId(id));
        }
        public ActionResult ShowComments(int id)
        {
            return PartialView(pageCommentRepository.getCommentByNewsId(id));
        }
    }
}