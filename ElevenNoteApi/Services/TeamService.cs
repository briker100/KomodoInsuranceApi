using Data;
using ElevenNoteApi.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class TeamService
    {
        private readonly Guid _userId;

        public TeamService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNote(TeamCreates model)
        {
            var entity =
                new Teams()
                {
                    OwnerID = _userId,
                    TeamName = model.TeamName,
                    TeamMembers = model.TeamMembers,
                    NumberPeopleTeam = model.NumberPeopleOnTeam
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TeamListItem> GetTeam()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teams
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new TeamListItem
                                {
                                    TeamId = e.TeamID,
                                    TeamName = e.TeamName,
                                    TeamMembers = e.TeamMembers,
                                    NumberPeopleOnTeam = e.NumberPeopleTeam
                                }
                        );
                return query.ToArray();
            }
        }

        public TeamDetail GetTeamById(int TeamID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamID == TeamID && e.OwnerID == _userId);
                return
                    new TeamDetail
                    {
                        TeamId = entity.TeamID,
                        TeamName = entity.TeamName,
                        TeamMembers = entity.TeamMembers,
                        NumberPeopleOnTeam = entity.NumberPeopleTeam,
                    };
            }
        }
        public bool UpdateNote(TeamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamID == model.TeamId && e.OwnerID == _userId);

                entity.TeamID = model.TeamId;
                entity.TeamName = model.TeamName;
                entity.TeamMembers = model.TeamMembers;
                entity.NumberPeopleTeam = model.NumberPeopleOnTeam;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int TeamID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamID == TeamID && e.OwnerID == _userId);

                ctx.Teams.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
