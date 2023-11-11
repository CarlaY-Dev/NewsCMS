using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer
{
    public class Page
    {
        [Key]
        public int PageID { get; set; }
        [Required(ErrorMessage = "لطفا {0} وارد نمایید")]
        [Display(Name = "گروه خبری")]
        public int GroupID { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} وارد نمایید")]
        [MaxLength(150)]
        public string Title { get; set; }
        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = "لطفا {0} وارد نمایید")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} وارد نمایید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Text { get; set; }
        [Display(Name = "بازدید")]
        public int Visit { get; set; }

        [Display(Name = "کلمات کلیدی")]
        public string Tags { get; set; }
        [Display(Name = "نام عکس")]
        public string ImageName { get; set; }
        [Display(Name = "نمایش در اسلایدر")]
        public bool ShowInSlider { get; set; }
        [Display(Name = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime CerateDate { get; set; }

        public virtual PageGroup pageGroup { get; set; }
        public virtual List<PageComment> PageComments { get; set; }
        public Page()
        {

        }
    }
}
