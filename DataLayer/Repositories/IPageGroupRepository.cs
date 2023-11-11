using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageGroupRepository : IDisposable
    {
        IEnumerable<PageGroup> GetAllGroups();
        PageGroup PageGroupGetById(int id);
        bool InsertGroup(PageGroup group);
        bool UpdateGroup(PageGroup group);
        bool DeleteGroup(int id);
        bool DeleteGroup(PageGroup group);
        IEnumerable<ShowGroupsViewModel> GetGroupsForView();
        void Save();
    }
}
