using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using ABP.TPLMS.Orgs.Dto;



namespace ABP.TPLMS.Orgs
{
    public interface IOrgAppService : IAsyncCrudAppService<//定义了CRUD方法

               OrgDto, //用来展示组织信息
               int, //Org实体的主键
               PagedOrgResultRequestDto, //获取组织信息的时候用于分页
               CreateUpdateOrgDto, //用于创建组织信息
               CreateUpdateOrgDto> //用于更新组织信息

    {
    }
}