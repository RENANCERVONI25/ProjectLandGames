using System.Collections.Generic;
using System.Linq;
using Solution.Locator.Roles.Dto;
using Solution.Locator.Users.Dto;

namespace Solution.Locator.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
