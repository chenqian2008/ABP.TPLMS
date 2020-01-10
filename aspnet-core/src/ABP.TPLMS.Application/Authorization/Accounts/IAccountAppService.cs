using System.Threading.Tasks;
using Abp.Application.Services;
using ABP.TPLMS.Authorization.Accounts.Dto;

namespace ABP.TPLMS.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
