using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageRepository : IDisposable
    {
        IEnumerable<Page> GetAllPages();
        Page PageGetById(int id);
        bool InsertPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(int id);
        bool DeletePage(Page page);
        void Save();
        IEnumerable<Page> TopNews(int take = 4);
        IEnumerable<Page> PageSlider();
        IEnumerable<Page> LastNews(int take = 4);
        IEnumerable<Page> ShowPagesByGroup(int Id);

        IEnumerable<Page> SearchPage(string search);
    }
}
