using DapperCV.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("Certifications")]
    public class Certification:ITable
    {
        [Key]
        public int Id { get; set; }

        [StringLength(1000)]
        public string Descripiton { get; set; }
    }
}
