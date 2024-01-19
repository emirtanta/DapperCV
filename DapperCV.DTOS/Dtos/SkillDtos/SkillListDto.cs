using DapperCV.DTOS.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.DTOS.Dtos.SkillDtos
{
    public class SkillListDto:IDto
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
    }
}
