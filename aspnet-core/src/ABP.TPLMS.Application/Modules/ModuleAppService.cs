using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ABP.TPLMS.Entitys;
using ABP.TPLMS.Modules.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABP.TPLMS.Modules
{
    public class ModuleAppService : ApplicationService, IModuleAppService
    {

        private readonly IRepository<Module> _moduleRepository;

        public ModuleAppService(IRepository<Module> moduleRepository)
        {

            _moduleRepository = moduleRepository;
        }

        public Task CreateAsync(CreateUpdateModuleDto input)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateUpdateModuleDto, Module>());
            var mapper = config.CreateMapper();
           
            var module = mapper.Map<Module>(input);
            return _moduleRepository.InsertAsync(module);
        }

        public Task UpdateAsync(CreateUpdateModuleDto input)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateUpdateModuleDto, Module>());
            var mapper = config.CreateMapper();

            var module = mapper.Map<Module>(input);
            return _moduleRepository.UpdateAsync(module);
        }

        public async Task<ListResultDto<ModuleDto>> GetAllItemAsync()
        {
            var books = await _moduleRepository.GetAllListAsync();

            return new ListResultDto<ModuleDto>(ObjectMapper.Map<List<ModuleDto>>(books));

        }

        public List<Module> GetAll()
        {
            var books = _moduleRepository.GetAllList();

            return books;
        }

        public async Task DeleteAsync(int Id)
        {
            await _moduleRepository.DeleteAsync(Id);

        }

        public void DeleteByID(int Id)
        {
            _moduleRepository.Delete(Id);

        }

    }

}