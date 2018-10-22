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
     public class ContractService
    {
        private readonly Guid _userId;

        public ContractService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNote(ContractCreate model)
        {
            var entity =
                new Contracts()
                {
                    OwnerID = _userId,
                    ContractID = model.ContractID,
                    ContractName = model.Name,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Contracts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ContractListItem> GetContracts()
        {   
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Contracts
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new ContractListItem
                                {
                                    ContractID = e.ContractID,
                                    Name = e.ContractName,
                                }
                        );
                return query.ToArray();
            }
        }

        public ContractDetails GetContractById(int ContractID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Contracts
                        .Single(e => e.ContractID == ContractID && e.OwnerID == _userId);
                return
                    new ContractDetails
                    {
                        ContractID = entity.ContractID,
                        Name = entity.ContractName,
                    };
            }
        }
        public bool UpdateContract(ContractEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Contracts
                        .Single(e => e.ContractID == model.ContractID && e.OwnerID == _userId);

                entity.ContractID = model.ContractID;
                entity.ContractName = model.Name;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteContract(int ContractID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Contracts
                        .Single(e => e.ContractID == ContractID && e.OwnerID == _userId);

                ctx.Contracts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
