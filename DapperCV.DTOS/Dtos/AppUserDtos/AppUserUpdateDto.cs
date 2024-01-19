using DapperCV.DTOS.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.DTOS.Dtos.AppUserDtos
{
    public class AppUserUpdateDto:IDto
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string? ImageUrl { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(15)]
        public string? PhoneNumber { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

        [StringLength(100)]
        public string? ShortDescripiton { get; set; }
    }
}
