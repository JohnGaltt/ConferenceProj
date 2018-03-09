using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace CorePluralSightFirst.Services
{
    public interface IConferenceService
    {
        Task<IEnumerable<ConferenceModel>> GetAll();

        Task<ConferenceModel> GetById(int id);

        Task<StatisticModel> GetStatistics();

        Task Add(ConferenceModel model); 
    }
}
