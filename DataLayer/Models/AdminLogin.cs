using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AdminLogin
    {
        [Key]
        public int LoginID { get; set; }
        [Display(Name = "نام کاربری")]  
        [Required(ErrorMessage = "لطفا {0} وارد نمایید")]
        [MaxLength(250)]

        public string UserName { get; set; }
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} وارد نمایید")]
        [MaxLength(150)]
        public string Password { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} وارد نمایید")]
        [MaxLength(150)]
        public string Email { get; set; }
    }
}
