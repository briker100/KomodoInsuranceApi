using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
     public class TeamCreate
    {
        [Required]
        public int TeamID { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public int NumberPeopleOnTeam { get; set; }
        [Required]
        public string TeamMembers { get; set; }
    }
}
