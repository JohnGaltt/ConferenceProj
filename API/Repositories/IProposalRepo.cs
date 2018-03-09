using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IProposalRepo
    {
        Task Add(ProposalModel model);

        Task<ProposalModel> Approve(int proposalId);

        Task<IEnumerable<ProposalModel>> GetAll(int conferenceId);
    }
}
