using CorePluralSightFirst.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePluralSightFirst.ViewComponents
{
    public class StatisticsViewComponent : ViewComponent
    {
        private readonly IConferenceService service;

        public StatisticsViewComponent(IConferenceService service)
        {
            this.service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string captionTitle)
        {
            ViewBag.Title = captionTitle;
            return View(await service.GetStatistics());
        }
    }
}
