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
    public class StatisticsController : Controller
    {
        private readonly IStatisticsRepo statisticsRepo;
        public StatisticsController(IStatisticsRepo statisticsRepo)
        {
            this.statisticsRepo = statisticsRepo;
        }

        public StatisticModel Get()
        {
            return statisticsRepo.GetStatistics();
        }
    }
}
