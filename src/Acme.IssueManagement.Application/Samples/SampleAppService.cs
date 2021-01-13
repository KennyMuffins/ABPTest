using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Acme.IssueManagement.Samples
{
    public class SampleAppService : IssueManagementAppService, ISampleAppService
    {
        //Test
        //private const string BaseUrl = "https://jsonplaceholder.typicode.com/todos/";

        private const string BaseUrl = "http://d010975baae3.ngrok.io/api/content/cake/content/";
        private readonly HttpClient _client;

        //public async Task<List<SampleDto>> GetAllAsync()
        //{
        //    var httpResponse = await _client.GetAsync(BaseUrl);

        //    if (!httpResponse.IsSuccessStatusCode)
        //    {
        //        throw new Exception("Cannot retrieve tasks");
        //    }

        //    var content = await httpResponse.Content.ReadAsStringAsync();
        //    var tasks = JsonConvert.DeserializeObject<List<SampleDto>>(content);

        //    return tasks;
        //}

        public SampleAppService(HttpClient client)
        {
            _client = client;

            _client.DefaultRequestHeaders.Authorization
             = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsImtpZCI6InJFTWRtT29kdU9MUEhKeGhrWTNOelEiLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE2MTA1MTA2MzMsImV4cCI6MTYxMzEwMjYzMywiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3QvaWRlbnRpdHktc2VydmVyIiwiY2xpZW50X2lkIjoiY2FrZTpkZWZhdWx0IiwianRpIjoiNUU0RUE4QkFEOUVBMTA0QjNBMUJDNEU4N0MyRDgwNTEiLCJpYXQiOjE2MTA1MTA2MzMsInNjb3BlIjpbInNxdWlkZXgtYXBpIl19.KiDcOBarCnHrJhUDEGQ2KIX3_wr_XWepH5bhedGwKoPPi4q6VFngZ09b8UN-3rF6kUZkDmkvVqZgeVus-VUaCjak8APiw2FXbRVTQxg1WkiazGIsqrx3eFtoJCqY2bqCRQoRmv68w5Q7qAU1Adszyh1TyBjvIZjeKQ5aWNeJniTjEb5gA-kAs_u4kE_f2fylVyIvLslox-O1EBSuHbmWONaQw1JYXr7O6RBpF3so0CRFvujvJlJcnHBzMpSj6R7XXX-NQDwoyMyHBlvAduGteRZQ5r_FwlJ73BElEp63idjJ1MDgCQrOB-XxHVVZZEW3T4G5XXoi7ZlAMD3Epv5vtg");
        }

        public async Task<Response> GetAsync()
        {

            var httpResponse = await _client.GetAsync(BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            //var tasks = JsonConvert.DeserializeObject<List<SampleDto>>(content);
            var tasks = JsonConvert.DeserializeObject<Response>(content);


            return JsonConvert.DeserializeObject<Response>(content);
        }

        public async Task<Response> CreateAsync()
        {
            Data newData = new Data(new Id(4),new UserId(4), new Title("Kenny4"), new IsCompleted(true));

            var jsonInString = JsonConvert.SerializeObject(newData);

            var httpResponse = await _client.PostAsync(BaseUrl, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            //var tasks = JsonConvert.DeserializeObject<List<SampleDto>>(content);
            var tasks = JsonConvert.DeserializeObject<Response>(content);


            return JsonConvert.DeserializeObject<Response>(content);
        }

        [Authorize]
        public Task<Response> GetAuthorizedAsync()
        {
            //return Task.FromResult(
            //    new SampleDto
            //    {
            //        Id = 1,
            //        UserId = 2,
            //        Title = "Kenny",
            //        IsCompleted = false
            //    }
            //);
            throw new NotImplementedException();
        }
    }
}