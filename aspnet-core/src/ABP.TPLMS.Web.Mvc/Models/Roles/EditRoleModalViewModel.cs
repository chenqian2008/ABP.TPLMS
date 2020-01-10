using Abp.AutoMapper;
using ABP.TPLMS.Roles.Dto;
using ABP.TPLMS.Web.Models.Common;

namespace ABP.TPLMS.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
