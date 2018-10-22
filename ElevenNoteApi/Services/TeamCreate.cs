using Data;
using ElevenNoteApi.Data;
using ElevenNoteApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class TeamCreate
    {
        private readonly Guid _userId;

        public TeamCreate(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNote(TeamCreate model)
        {
            var entity =
                new Teams()
                {
                    OwnerID = _userId,
                    TeamName = model.TeamName,
                    TeamMembers = model.TeamMembers,
                    NumberPeopleTeam = model.NumberPeopleOnTeam,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TeamListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teams
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TeamListItem
                                {
                                    NoteId = e.NoteId,
                                    Title = e.Title,
                                    Content = e.Content,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        public NoteDetail GetNoteById(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == noteId && e.OwnerId == _userId);
                return
                    new NoteDetail
                    {
                        NoteId = entity.NoteId,
                        Title = entity.Title,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateNote(NoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == model.NoteId && e.OwnerId == _userId);
                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == noteId && e.OwnerId == _userId);

                ctx.Notes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
