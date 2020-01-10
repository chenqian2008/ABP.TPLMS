using System.Collections.Generic;
using ABP.TPLMS.Roles.Dto;

namespace ABP.TPLMS.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}