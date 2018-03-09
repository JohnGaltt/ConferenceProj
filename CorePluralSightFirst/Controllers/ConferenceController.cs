using CorePluralSightFirst.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePluralSightFirst.Controllers
{
    
    public class ConferenceController : Controller
    {
        private readonly IConferenceService conferenceService;

        public ConferenceController(IConferenceService conferenceService)
        {
            this.conferenceService = conferenceService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Conference Overview";
            return View(await conferenceService.GetAll());
        }

        //public Task<IEnumerable<ConferenceModel>> Index()
        //{
        //    ViewBag.Title = "Conference Overview";
        //    return conferenceService.GetAll();
        //}

        public IActionResult Add()
        {
            ViewBag.Title = "Add Conference";
            return View(new ConferenceModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConferenceModel model)
        {
            if (ModelState.IsValid)
            {
                await conferenceService.Add(model);
            }
            return RedirectToAction("Index");
        }
    }
}
