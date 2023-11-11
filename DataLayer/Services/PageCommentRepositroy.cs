using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageCommentRepositroy : IPageCommentRepository
    {
       
        Mycmscontext db;
        public PageCommentRepositroy(Mycmscontext context)
        {
            db = context;
        }

     

        public IEnumerable<PageComment> getCommentByNewsId(int pageId)
        {
            return db.PageComment.Where(c => c.PageID == pageId);
        }


        public bool AddPageComment(PageComment pageComment)
        {
            try
            {
                db.PageComment.Add(pageComment);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
