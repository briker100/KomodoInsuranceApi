using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Teams
    {
        [Key]
        public int TeamID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }   
        [Required]
        [MinLength(3, ErrorMessage = "Please Enter A Team Name At Least 3 Charectors Long.")]
        [MaxLength(20, ErrorMessage = "Please Enter A Team Name Under 20 Charectors Long.")]
        public string TeamName { get; set; }
        [Required]
        public string TeamMembers { get; set; }
        [Required]
        public int NumberPeopleTeam { get; set; }   
    }
}
