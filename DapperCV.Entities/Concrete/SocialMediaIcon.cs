using DapperCV.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("SocialMediaIcons")]
    public class SocialMediaIcon:ITable
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string? Link { get; set; }

        [StringLength(100)]
        public string? Icon { get; set; }

        public int AppUserId { get; set; }
    }
}
