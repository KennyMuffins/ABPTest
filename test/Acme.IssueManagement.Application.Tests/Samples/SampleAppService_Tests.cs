﻿using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Acme.IssueManagement.Samples
{
    public class SampleAppService_Tests : IssueManagementApplicationTestBase
    {
        private readonly ISampleAppService _sampleAppService;

        public SampleAppService_Tests()
        {
            _sampleAppService = GetRequiredService<ISampleAppService>();
        }

        [Fact]
        public async Task GetAsync()
        {
            var result = await _sampleAppService.GetAsync();
            result.total.ShouldBe(1);
        }

        [Fact]
        public async Task GetAuthorizedAsync()
        {
            var result = await _sampleAppService.GetAuthorizedAsync();
            result.total.ShouldBe(1);
        }
    }
}
