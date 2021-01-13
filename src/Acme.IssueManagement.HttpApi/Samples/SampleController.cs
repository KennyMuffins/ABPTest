using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Acme.IssueManagement.Samples
{
    [RemoteService]
    [Route("api/IssueManagement/sample")]
    public class SampleController : IssueManagementController, ISampleAppService
    {
        private readonly ISampleAppService _sampleAppService;

        public SampleController(ISampleAppService sampleAppService)
        {
            _sampleAppService = sampleAppService;
        }

        [HttpGet]
        public async Task<Response> GetAsync()
        {
            Console.WriteLine("testing");

            return await _sampleAppService.GetAsync();
        }


        [HttpGet]
        [Route("authorized")]
        [Authorize]
        public async Task<Response> GetAuthorizedAsync()
        {
            return await _sampleAppService.GetAsync();
        }

        [HttpPost]
        public async Task<Response> CreateAsync()
        {
            return await _sampleAppService.CreateAsync();
        }
    }
}
