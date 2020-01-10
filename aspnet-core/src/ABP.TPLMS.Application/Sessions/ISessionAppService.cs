using System.Threading.Tasks;
using Abp.Application.Services;
using ABP.TPLMS.Sessions.Dto;

namespace ABP.TPLMS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
