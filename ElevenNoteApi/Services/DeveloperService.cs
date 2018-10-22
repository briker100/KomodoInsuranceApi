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
    class DeveloperService
    {
        private readonly Guid _userId;

        public DeveloperService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDeveloper(DeveloperCreate model)
        {
            var entity =
                new Developers()
                {
                    OwnerID = _userId,
                    DevelopersID = model.DeveloperID,
                    DevelopersName = model.Name,
                    DevelopersHiredDate = model.DateHired,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Developers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DeveloperListItem> GetDeveloper()
        {   
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Developers
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new DeveloperListItem
                                {
                                    DeveloperID = e.DevelopersID,
                                    Name = e.DevelopersName,
                                    DateHired = e.DevelopersHiredDate,
                                }
                        );
                return query.ToArray();
            }
        }

        public DeveloperDetails GetDeveloperbyID(int DeveloperID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Developers
                        .Single(e => e.DevelopersID == DeveloperID && e.OwnerID == _userId);
                return
                    new DeveloperDetails
                    {
                        DeveloperID = entity.DevelopersID,
                        Name = entity.DevelopersName,
                        DateHired = entity.DevelopersHiredDate,
                    };
            }
        }
        public bool UpdateDeveloper(DeveloperEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Developers
                        .Single(e => e.DevelopersID == model.DeveloperID && e.OwnerID == _userId);

                entity.DevelopersID = model.DeveloperID;
                entity.DevelopersName = model.Name;
                entity.DevelopersHiredDate = model.DateHired;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDeveloper(int DeveloperID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Developers
                        .Single(e => e.DevelopersID == DeveloperID && e.OwnerID == _userId);

                ctx.Developers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
