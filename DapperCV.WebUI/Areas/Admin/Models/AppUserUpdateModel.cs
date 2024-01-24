using System.ComponentModel.DataAnnotations;

namespace DapperCV.WebUI.Areas.Admin.Models
{
    public class AppUserUpdateModel
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Display(Name ="Resim")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage ="Ad alanı zorunludur")]
        [StringLength(50)]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        [StringLength(50)]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [StringLength(15)]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [StringLength(500)]
        public string? Address { get; set; }

        [StringLength(100)]
        [Display(Name = "Ön Yazı")]
        public string? ShortDescripiton { get; set; }

        [StringLength(1000)]
        public IFormFile? Picture { get; set; }
    }
}
