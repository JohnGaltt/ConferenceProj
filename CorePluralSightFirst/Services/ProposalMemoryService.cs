using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePluralSightFirst.Services
{
    public class ProposalMemoryService : IProposalService
    {
        private readonly List<ProposalModel> proposals = new List<ProposalModel>();

        public ProposalMemoryService()
        {
            proposals.Add(new ProposalModel
            {
                Id = 1,
                ConferenceId = 1,
                Speaker = "Alex",
                Title = "Asp.Net Security"
            });

            proposals.Add(new ProposalModel
            {
                Id = 2,
                ConferenceId = 2,
                Speaker = "Dima",
                Title = "Asp.Net Mobility"
            });

            proposals.Add(new ProposalModel
            {
                Id = 3,
                ConferenceId = 3,
                Speaker = "Roman",
                Title = "Javascript Security"
            });
        }

        public Task Add(ProposalModel model)
        {
            model.Id = proposals.Max(x => x.Id) + 1;
            proposals.Add(model);
            return Task.CompletedTask;
        }

        public Task<ProposalModel> Approve(int proposalId)
        {
           return Task.Run(() =>
            {
                var proposal = proposals.First(p => p.Id == proposalId);
                proposal.Approved = true;
                return proposal;
            });
        }

        public Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
             return Task.Run(() => proposals.Where(x=>x.ConferenceId == conferenceId).AsEnumerable());
        }
    }
}
