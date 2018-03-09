using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Models;

namespace CorePluralSightFirst.Services
{
    public class ConferenceApiService : IConferenceService
    {
        private readonly HttpClient client;

        public ConferenceApiService(HttpClient client)
        {
            this.client = client;
        }

        public async Task Add(ConferenceModel model)
        {
            await client.PostAsJsonAsync("v1/Proposal", model);
        }

        public async Task<IEnumerable<ConferenceModel>> GetAll()
        {
            
                List<ConferenceModel> result;
            try
            {
                var response = await client.GetAsync("v1/Conference");
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<List<ConferenceModel>>();
                }
                else
                {
                    throw new Exception();
                }
                return result;
            }
            catch (HttpRequestException e)
                {
                Console.WriteLine(e.Message);
                result = new List<ConferenceModel>();
                return result;
            }
        }

        public async Task<ConferenceModel> GetById(int id)
        {
            var result = new ConferenceModel();
            var response = await client.GetAsync($"/v1/Conference/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<ConferenceModel>();
            }
            throw new ArgumentException("Error");
        }

        public async Task<StatisticModel> GetStatistics()
        {
            var result = new StatisticModel();
            var response = await client.GetAsync($"/v1/Statistics");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<StatisticModel>();
            }
            throw new ArgumentException("Error");
        }
    }
}
