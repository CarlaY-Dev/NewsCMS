using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageRepository : IPageRepository
    {
        Mycmscontext db;
        public PageRepository(Mycmscontext db)
        {
            this.db = db;
        }
        public IEnumerable<Page> GetAllPages()
        {
            return db.Page;
        }
        public Page PageGetById(int id)
        {
            return db.Page.Find(id);
        }

        public bool InsertPage(Page page)
        {
            try
            {
                db.Page.Add(page);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdatePage(Page page)
        {
            try
            {
               db.Entry(page).State=System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeletePage(Page page)
        {

            try
            {
                db.Entry(page).State = System.Data.Entity.EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeletePage(int id)
        {

            try
            {
                var page = PageGetById(id);
                DeletePage(page);
                return true;
            }
            catch
            {
                return false;
            }
        }

     


        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Page> TopNews(int take = 4)
        {
            return db.Page.OrderByDescending(p=> p.Visit).Take(take);
        }

        public IEnumerable<Page> PageSlider()
        {
            return db.Page.Where(p=> p.ShowInSlider==true);
        }

        public IEnumerable<Page> LastNews(int take = 4)
        {
            return db.Page.OrderByDescending(p=>p.CerateDate).Take(take);
        }

        public IEnumerable<Page> ShowPagesByGroup(int Id)
        {
            return db.Page.Where(p => p.GroupID == Id);
        }

        public IEnumerable<Page> SearchPage(string search)
        {
            return db.Page.Where(p=> p.Title.Contains(search)|| p.ShortDescription.Contains(search)
            || p.Tags.Contains(search)|| p.Text.Contains(search)).Distinct();
        }
    }
}
