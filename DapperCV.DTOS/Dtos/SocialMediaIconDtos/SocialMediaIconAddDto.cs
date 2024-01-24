using DapperCV.DTOS.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.DTOS.Dtos.SocialMediaIconDtos
{
    public class SocialMediaIconAddDto:IDto
    {

        [StringLength(500)]
        [Display(Name ="Bağlantı Adresi")]
        public string? Link { get; set; }

        [StringLength(100)]
        [Display(Name ="İkon")]
        public string? Icon { get; set; }

        [Display(Name ="Kullanıcı")]
        public int AppUserId { get; set; }
    }
}
