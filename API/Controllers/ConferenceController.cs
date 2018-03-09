using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace API.Con
{
    [Route("v1/[controller]")]
    public class ConferenceController : Controller
    {
        private readonly IConferenceRepo repo;

        public ConferenceController(IConferenceRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult GetAll()
        {
            var conferences = repo.GetAll();
            if (!conferences.Any())
            {
                return new NoContentResult();
            }
            return new ObjectResult(conferences);            
        }

        [HttpPost]
        public ConferenceModel Add([FromBody]ConferenceModel conference)
        {
            return repo.Add(conference);  
        }
    }
}