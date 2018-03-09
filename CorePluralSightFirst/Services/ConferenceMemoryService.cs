using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace CorePluralSightFirst.Services
{
    public class ConferenceMemoryService : IConferenceService
    {
        private readonly List<ConferenceModel> conferences = new List<ConferenceModel>();

        public ConferenceMemoryService()
        {
            conferences.Add(new ConferenceModel { Id = 1, Location = "USA", Name = "MSP EVENT", AtendeeTotal = 5, Start = DateTime.Parse("25/02/2018") });
            conferences.Add(new ConferenceModel { Id = 2, Location = "Ukraine", Name = "Google EVENT", AtendeeTotal = 10, Start = DateTime.Parse("25/02/2011") });
        }

        public Task Add(ConferenceModel model)
        {
            model.Id = conferences.Max(c => c.Id) + 1;
            conferences.Add(model);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ConferenceModel>> GetAll()
        {
            return Task.Run(() => conferences.AsEnumerable());
        }

        public Task<ConferenceModel> GetById(int id)
        {
            return Task.Run(() => conferences.First(x=>x.Id == id));
        }

        public Task<StatisticModel> GetStatistics()
        {
            return Task.Run(() =>
            {
                return new StatisticModel
                {
                    NumberOfAttendees = conferences.Sum(x => x.AtendeeTotal),
                    AverageConferenceAttendees = (int)conferences.Average(x => x.AtendeeTotal)
                };
            });
        }
    }
}
