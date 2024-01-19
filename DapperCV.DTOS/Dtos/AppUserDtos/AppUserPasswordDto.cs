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

        [StringLength(50)]
        public string Password { get; set; }
    }
}
