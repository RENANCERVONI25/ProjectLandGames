using System.Collections.Generic;
using Solution.Locator.Roles.Dto;
using Solution.Locator.Users.Dto;

namespace Solution.Locator.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
