﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Contracts
    {
        [Key]
        public int ContractID { get; set; }
        [Required]
        public string ContractName { get; set; }
        [Required]
        public string Team { get; set; }
        [Required]
        public string Developer { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

    }
}
