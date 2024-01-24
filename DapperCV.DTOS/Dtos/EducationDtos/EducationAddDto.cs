using DapperCV.DTOS.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.DTOS.Dtos.EducationDtos
{
    public class EducationAddDto:IDto
    {

        [StringLength(100)]
        [Display(Name ="Eğitim Aldığı Kurum")]
        public string Title { get; set; }

        [StringLength(200)]
        [Display(Name = "Eğitim Alanı")]
        public string SubTitle { get; set; }

        [StringLength(1000)]
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Başlangıç Tarihi")]
        public DateTime? StartDate { get; set; } = DateTime.Now;

        [Display(Name = "Bitiş Tarihi")]
        public DateTime? EndDate { get; set; }
    }
}
