using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer
{
    public class PageComment
    {
         [Key]
        public int CommentID { get; set; }
        [Display(Name = "خبر")]
        [Required(ErrorMessage = "لطفا {0} وارد نمایید")]
        public int PageID { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} وارد نمایید")]
        [MaxLength(150)]

        public string Name { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} وارد نمایید")]
        [MaxLength(200)]
        public string Email { get; set; }
        [Display(Name = "نظر")]
        [Required(ErrorMessage = "لطفا {0} وارد نمایید")]
        [MaxLength(500)]
        public string Comment { get; set; }
        [Display(Name = "تاریخ")]
      
        public DateTime CreateDate { get; set; }

        public virtual Page page { get; set; }
        public PageComment()
        {

        }
    }
}
