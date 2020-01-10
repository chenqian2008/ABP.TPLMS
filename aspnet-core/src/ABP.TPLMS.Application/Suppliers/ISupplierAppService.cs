using Abp.Application.Services;
using ABP.TPLMS.Suppliers.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABP.TPLMS.Suppliers
{
    public interface ISupplierAppService : IAsyncCrudAppService<//定义了CRUD方法
             SupplierDto, //用来展示供应商
             int, //Supplier实体的主键
             PagedSupplierResultRequestDto, //获取供应商的时候用于分页
             CreateUpdateSupplierDto, //用于创建供应商
             CreateUpdateSupplierDto> //用于更新供应商
    {
    }
}