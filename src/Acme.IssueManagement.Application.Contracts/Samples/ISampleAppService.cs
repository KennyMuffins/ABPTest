using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.IssueManagement.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        //public Task<List<SampleDto>> GetAllAsync();

        Task<Response> GetAsync();

        Task<Response> GetAuthorizedAsync();

        Task<Response> CreateAsync();
    }
}
