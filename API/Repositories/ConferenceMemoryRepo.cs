using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class ConferenceMemoryRepo : IConferenceRepo
    {
        private readonly List<ConferenceModel> conferences = new List<ConferenceModel>();

        public ConferenceMemoryRepo()
        {
            conferences.Add(new ConferenceModel { Id = 1, Location = "USA", Name = "MSP EVENT", AtendeeTotal = 5, Start = DateTime.Parse("25/02/2018") });
            conferences.Add(new ConferenceModel { Id = 2, Location = "India", Name = "MSP EVENT", AtendeeTotal = 29, Start = DateTime.Parse("23/01/2118") });
        }

        public ConferenceModel Add(ConferenceModel model)
        {
            model.Id = conferences.Max(c => c.Id) + 1;
            return model;
            
        }

        public IEnumerable<ConferenceModel> GetAll()
        {
            return conferences;
        }

        //public Task<IEnumerable<ConferenceModel>> GetAll()
        //{
        //    return Task.Run(() => conferences.AsEnumerable());
        //}

        public Task<ConferenceModel> GetById(int id)
        {
            return Task.Run(() => conferences.First(x => x.Id == id));
        }

        public Task<StatisticModel> GetStatistics()
        {
            return Task.Run(() =>
            {
                return new StatisticModel
                {
                    AverageConferenceAttendees = (int)conferences.Average(x => x.AtendeeTotal),
                    NumberOfAttendees = conferences.Sum(x => x.AtendeeTotal)
                };
            });
        }

    //public Task Add(ConferenceModel model)
    //{
    //    model.Id = conferences.Max(c => c.Id) + 1;
    //    conferences.Add(model);
    //    return Task.Run(() => Task.CompletedTask);
    //}
}
}
