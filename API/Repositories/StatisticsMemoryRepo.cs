using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace API.Repositories
{
    public class StatisticsMemoryRepo : IStatisticsRepo
    {
        private readonly IConferenceRepo conferenceRepo;

        public StatisticsMemoryRepo(IConferenceRepo conferenceRepo)
        {
            this.conferenceRepo = conferenceRepo;
        }

       public StatisticModel GetStatistics()
        {
            var conferences = conferenceRepo.GetAll();
            return new StatisticModel
            {
                AverageConferenceAttendees = (int)conferences.Average(x => x.AtendeeTotal),
                NumberOfAttendees = conferences.Sum(x => x.AtendeeTotal)
            };

        }
    }
}
