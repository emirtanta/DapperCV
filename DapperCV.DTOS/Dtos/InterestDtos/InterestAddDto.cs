using DapperCV.DTOS.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.DTOS.Dtos.InterestDtos
{
    public class InterestAddDto:IDto
    {

        [StringLength(50)]
        [Display(Name ="Hobi Adı")]
        public string Name { get; set; }
    }
}
