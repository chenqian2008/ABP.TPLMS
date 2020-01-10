using Abp.Application.Services;
using Abp.Domain.Repositories;
using ABP.TPLMS.Entitys;
using ABP.TPLMS.Orgs.Dto;
using System;
using System.Collections.Generic;
using System.Text;


namespace ABP.TPLMS.Orgs
{

    public class OrgAppService : AsyncCrudAppService<Org, OrgDto, int, PagedOrgResultRequestDto,
                            CreateUpdateOrgDto, CreateUpdateOrgDto>, IOrgAppService

    {
        public OrgAppService(IRepository<Org, int> repository)

            : base(repository)

        {

        }
    }
}