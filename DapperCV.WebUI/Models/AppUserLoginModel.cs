using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace DapperCV.WebUI.Models
{
    public class AppUserLoginModel
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(100)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Şifre zorunludur")]
        [Display(Name = "Şifre")]
        [StringLength(50)]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
