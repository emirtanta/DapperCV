using DapperCV.DTOS.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.DTOS.Dtos.ExprerienceDtos
{
    public class ExprerienceAddDto:IDto
    {

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(200)]
        public string SubTitle { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
