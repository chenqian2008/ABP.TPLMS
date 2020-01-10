using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ABP.TPLMS.Entitys;
using ABP.TPLMS.Modules.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABP.TPLMS.Modules
{
    public interface IModuleAppService : IApplicationService
    {

        Task CreateAsync(CreateUpdateModuleDto input);
        Task UpdateAsync(CreateUpdateModuleDto input);
        Task<ListResultDto<ModuleDto>> GetAllAsync();
        List<Module> GetAll();
        Task DeleteAsync(int Id);
        void Delete(int Id);
    }
}
