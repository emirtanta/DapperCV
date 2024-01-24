using DapperCV.DTOS.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.DTOS.Dtos.SkillDtos
{
    public class SkillAddDto:IDto
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name ="Yetenek Adı")]
        public string Name { get; set; }
    }
}
