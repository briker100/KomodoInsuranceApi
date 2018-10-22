using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TeamListItem
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamMembers { get; set; }
        public int NumberPeopleOnTeam { get; set; }
    }
}
