using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Con
{
    [Route("v1/[controller]")]
    public class ProposalController : Controller
    {
        private readonly IProposalRepo proposalRepo;

        public ProposalController(IProposalRepo proposalRepo)
        {
            this.proposalRepo = proposalRepo;
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProposalModel model)
        {
            var addedProposal = proposalRepo.Add(model);
            return CreatedAtRoute("GetById", new { id = addedProposal.Id }, addedProposal);
        }

        [HttpPut("{proposalId}")]
        public IActionResult Approve(int proposalId)
        {
            try
            {
                return new ObjectResult(proposalRepo.Approve(proposalId));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}
