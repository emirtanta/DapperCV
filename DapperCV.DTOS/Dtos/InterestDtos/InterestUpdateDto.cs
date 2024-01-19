﻿using DapperCV.DTOS.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.DTOS.Dtos.InterestDtos
{
    public class InterestUpdateDto:IDto
    {
        [Key]
        public int Id { get; set; }

        [StringLength(1000)]
        public string Descripiton { get; set; }
    }
}
