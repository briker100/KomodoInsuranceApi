using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
     public class DeveloperCreate
    {
        [Required]
        public int DeveloperID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateHired { get; set; }
    }
}
