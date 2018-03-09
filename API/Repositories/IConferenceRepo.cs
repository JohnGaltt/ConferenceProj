using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IConferenceRepo
    {
        IEnumerable<ConferenceModel> GetAll();

        Task<ConferenceModel> GetById(int id);

        Task<StatisticModel> GetStatistics();

        ConferenceModel Add(ConferenceModel model);
    }
}
