using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer
{
    public class ShowGroupsViewModel
    {
        public int GroupID { get; set; }
        public string GroupTitle { get; set; }

        public int PageCount { get; set; }

    }
}
