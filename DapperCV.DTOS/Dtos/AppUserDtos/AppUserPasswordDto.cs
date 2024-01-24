using DapperCV.DTOS.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.DTOS.Dtos.AppUserDtos
{
    public class AppUserPasswordDto:IDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Parola zorunludur")]
        [StringLength(50)]
        [Display(Name ="Şifre")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Parola tekrar zorunludur")]
        [StringLength(50)]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
