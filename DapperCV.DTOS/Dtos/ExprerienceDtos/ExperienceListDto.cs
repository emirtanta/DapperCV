using DapperCV.DTOS.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.DTOS.Dtos.ExprerienceDtos
{
    public class ExperienceListDto:IDto
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "Ünvan")]
        public string Title { get; set; }

        [StringLength(200)]
        [Display(Name = "Firma")]
        public string SubTitle { get; set; }

        [StringLength(1000)]
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Başlangıç tarihi")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Bitiş Tarihi")]
        public DateTime? EndDate { get; set; }
    }
}
