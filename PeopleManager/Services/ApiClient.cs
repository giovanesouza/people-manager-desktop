using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleManager.Services
{
    public class ApiClient
    {
        private readonly RestClient _client;

        public ApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        /// <summary>
        /// Returns a List with 'n' Names.
        /// </summary>
        /// <param name="totalNames">Sets the total of items to be returned</param>
        public async Task<List<string>> GetNames(int totalNames)
        {
            return await GetData("nomes", totalNames);
        }

        /// <summary>
        /// Returns a List with 'n' Surnames.
        /// </summary>
        /// <param name="totalSurnames">Sets the total of items to be returned</param>
        public async Task<List<string>> GetSurname(int totalSurnames)
        {
            return await GetData("apelidos", totalSurnames);
        }

        private async Task<List<string>> GetData(string endpoint, int n)
        {
            var request = new RestRequest($"{endpoint}/{n}");
            var response = await _client.ExecuteAsync<List<string>>(request);
            return response.Data;
        }

    }
}
