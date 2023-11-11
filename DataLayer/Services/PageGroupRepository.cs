using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroupRepository : IPageGroupRepository
    {
        Mycmscontext Db;
        public PageGroupRepository(Mycmscontext db)
        {
            this.Db = db;
        }

        public IEnumerable<PageGroup> GetAllGroups()
        {
            return Db.PageGroup;

        }
        public PageGroup PageGroupGetById(int id)
        {
            return Db.PageGroup.Find(id);
        }
        public bool InsertGroup(PageGroup group)
        {
            try
            {
                Db.PageGroup.Add(group);
                return true;
            }
            catch
            {
                return false;

            }
        }

        public bool UpdateGroup(PageGroup group)
        {

            try
            {
                Db.Entry(group).State = System.Data.Entity.EntityState.Modified;
                
                return true;
            }
            catch
            {
                return false;

            }
        }
        public bool DeleteGroup(PageGroup group)
        {
            try
            {
                Db.Entry(group).State = System.Data.Entity.EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;

            }
        }
        public bool DeleteGroup(int id)
        {
            try
            {
                var group=PageGroupGetById(id);
                DeleteGroup(group);
                return true;
            }
            catch
            {
                return false;

            }
        }

      
        public void Save()
        {
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public IEnumerable<ShowGroupsViewModel> GetGroupsForView()
        {
            return Db.PageGroup.Select(g => new ShowGroupsViewModel()
            {
                GroupID= g.GroupID,
                GroupTitle= g.GroupTitle,
                PageCount=g.Pages.Count
            });
        }
    }
}
