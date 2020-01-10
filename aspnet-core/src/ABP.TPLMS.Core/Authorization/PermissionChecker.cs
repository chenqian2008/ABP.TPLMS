using Abp.Authorization;
using ABP.TPLMS.Authorization.Roles;
using ABP.TPLMS.Authorization.Users;

namespace ABP.TPLMS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
