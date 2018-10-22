using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Developers
    {
        [Key]
        public int DevelopersID { get; set; }
        [Required]
        public string DevelopersName { get; set; }
        [Required]
        public DateTime DevelopersHiredDate { get; set; }

        [Required]
        public Guid OwnerID { get; set; }
    }
}
