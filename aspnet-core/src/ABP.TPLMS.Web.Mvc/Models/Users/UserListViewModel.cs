using System.Collections.Generic;
using ABP.TPLMS.Roles.Dto;
using ABP.TPLMS.Users.Dto;

namespace ABP.TPLMS.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
